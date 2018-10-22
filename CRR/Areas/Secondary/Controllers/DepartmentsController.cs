using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Helpers;
using CRR.Models.Entidades;
using CRR.Models.Vistas.Helpers;
using CRR.Models.Vistas.SelfControl;

namespace CRR.Areas.Secondary.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // GET: Secondary/Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [RenderAjaxPartialScripts]
        public ActionResult GetDepartments()
        {
            var list = db.Departments.Where(w => w.Active == true).Select(w => w.Name).ToList();

            return Json(new { list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Report(int weekNo, string Departments, string Shifts)
        {
            Parameters parameter = new Parameters();
            parameter.weekNo = weekNo;
            parameter.parameter1 = Departments;
            parameter.parameter2 = Shifts;

            return PartialView(parameter);
        }

        [RenderAjaxPartialScripts]
        public ActionResult Parametros(int weekNo, string Departments)
        {
            IList<SelfControlReportList> lists = new List<SelfControlReportList>();
            List<string> listDepartments;
            List<int> listShifts = new List<int>(new int[] { 1, 2, 3 });

            if (Departments != null)
            {
                listDepartments = Departments.Split(',').ToList();
            }
            else
            {
                listDepartments = db.Departments.Select(d => d.Name).ToList();
            }

            var listDays = Week.getDaysofWeek(weekNo);
            var rtData = db.RunningTimeData.Where(r => (r.WeekNo == weekNo) ).ToList();
            var qtmData = db.QTMData.Where(r => r.WeekNo == weekNo).ToList();
            var visualData = db.VisualData.Where(r => r.WeekNo == weekNo).ToList();
            var frecuency = (int)db.SelfControlSpecs.Where(s => s.Descripcion == "Frecuency").Select(s => s.Value).FirstOrDefault();
            var i = 0;

            foreach (var item in listDays)
            {
                SelfControlReportList list = new SelfControlReportList();                
                list.DayofWeek = item.Day;
                list.Date = item.Date;
                i++;

                foreach (var department in listDepartments)
                {
                    List<SelfControlByShift> shifts = new List<SelfControlByShift>();
                    list.Item = department;
                    var workCenters = db.WorkCenters.Where(w => w.DepartmentName == department).Select(w => w.Name).ToList();

                    foreach (var _shift in listShifts)
                    {
                        double? totalQTM = 0;
                        double? totalVisual = 0;

                        SelfControlByShift shift = new SelfControlByShift();
                        shift.Item = _shift;

                        foreach (var wItem in workCenters)
                        {
                            totalQTM = totalQTM + (qtmData.Where(q => (q.IdWorkCenter == wItem) && (q.DateBegin == item.Date) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                            totalVisual = totalVisual + (visualData.Where(q => (q.IdWorkCenter == wItem) && (q.DateBegin == item.Date) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                        }

                        var listMaker = rtData
                            .Where(x => (workCenters.Contains(x.IdWorkCenter)) && (item.Date >= x.BeginTime && item.Date <= x.EndTime) && (x.Shift == _shift) && (x.Type == "Maker"))
                            .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                            {
                                ItemName = department,
                                Parameter = (int)totalQTM,
                                Sampling = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum() / 60) / frecuency,
                                WorkingTime = (cant.Sum() / 60),
                                Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : ((int)totalQTM * 100) / ((cant.Sum() / 60) / frecuency)
                            }).FirstOrDefault();

                        var listPacker = rtData
                                .Where(x => (workCenters.Contains(x.IdWorkCenter)) && (item.Date >= x.BeginTime && item.Date <= x.EndTime) && (x.Shift == _shift) && (x.Type == "Packer"))
                                .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                                {
                                    ItemName = department,
                                    Parameter = (int)totalVisual,
                                    Sampling = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum() / 60) / frecuency,
                                    WorkingTime = cant.Sum() / 60,
                                    Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : ((int)totalVisual * 100) / ((cant.Sum() / 60) / frecuency)
                                }).FirstOrDefault();

                        shift.Physical = new SelfControlReportView();
                        shift.Physical = listMaker;
                        shift.Visual = new SelfControlReportView();
                        shift.Visual = listPacker;
                        shifts.Add(shift);
                    }

                    list.Shift = new List<SelfControlByShift>();
                    list.Shift = shifts;
                    lists.Add(list);
                }
            }

            //Weekly resume
            foreach (var department in listDepartments)
            {
                SelfControlReportList dList = new SelfControlReportList();
                List<SelfControlByShift> shifts = new List<SelfControlByShift>();
                dList.Item = department;
                dList.DayofWeek = "Resumen Semanal";

                var workCenters = db.WorkCenters.Where(w => w.DepartmentName == department).Select(w => w.Name).ToList();

                foreach (var _shift in listShifts)
                {
                    double? totalQTM = 0;
                    double? totalVisual = 0;

                    SelfControlByShift shift = new SelfControlByShift();
                    shift.Item = _shift;

                    foreach (var wItem in workCenters)
                    {
                        totalQTM = totalQTM + (qtmData.Where(q => (q.IdWorkCenter == wItem) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                        totalVisual = totalVisual + (visualData.Where(q => (q.IdWorkCenter == wItem) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                    }

                    var listMaker = rtData
                        .Where(x => (workCenters.Contains(x.IdWorkCenter)) && (x.Shift == _shift) && (x.Type == "Maker"))
                        .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                        {
                            ItemName = department,
                            Parameter = (int)totalQTM,
                            Sampling = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum() / 60) / frecuency,
                            WorkingTime = (cant.Sum() / 60),
                            Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : ((int)totalQTM * 100) / ((cant.Sum() / 60) / frecuency)
                        }).FirstOrDefault();

                    var listPacker = rtData
                            .Where(x => (workCenters.Contains(x.IdWorkCenter)) && (x.Shift == _shift) && (x.Type == "Packer"))
                            .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                            {
                                ItemName = department,
                                Parameter = (int)totalVisual,
                                Sampling = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum() / 60) / frecuency,
                                WorkingTime = cant.Sum() / 60,
                                Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : ((int)totalVisual * 100) / ((cant.Sum() / 60) / frecuency)
                            }).FirstOrDefault();

                    shift.Physical = new SelfControlReportView();
                    shift.Physical = listMaker;
                    shift.Visual = new SelfControlReportView();
                    shift.Visual = listPacker;
                    shifts.Add(shift);
                }

                dList.Shift = new List<SelfControlByShift>();
                dList.Shift = shifts;
                lists.Add(dList);
            }
            

            return Json(new { lists }, JsonRequestBehavior.AllowGet);
        }

        // GET: Secondary/Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secondary/Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Facility,Company,CalendarID,Active")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Secondary/Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Secondary/Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Facility,Company,CalendarID,Active")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Secondary/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Secondary/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
