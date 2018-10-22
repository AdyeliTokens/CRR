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
    public class WorkCentersController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/WorkCenters
        public ActionResult Index()
        {
            return View(db.WorkCenters.ToList());
        }

        // GET: Secondary/WorkCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenters.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        [RenderAjaxPartialScripts]
        public ActionResult GetWorkCenters()
        {
            var list = db.WorkCenters.Where(w => w.Active == true).Select(w => w.Name).ToList();

            return Json(new { list }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Report(int weekNo, string WorkCenters)
        {
            Parameters parameter = new Parameters();
            parameter.weekNo = weekNo;
            parameter.parameter1 = WorkCenters;

            return PartialView(parameter);
        }

        [RenderAjaxPartialScripts]
        public ActionResult Parametros(int weekNo, string WorkCenters)
        {
            IList<SelfControlReportList> lists = new List<SelfControlReportList>();
            List<string> listWorkCenters;
            List<int> listShifts = new List<int>(new int[] { 1, 2, 3 });

            if (WorkCenters != null)
            {
                listWorkCenters = WorkCenters.Split(' ').ToList();
            }
            else
            {
                listWorkCenters = db.WorkCenters.Select(d => d.Name).ToList();
            }

            var listDays = Week.getDaysofWeek(weekNo);
            var rtData = db.RunningTimeData.Where(r => r.WeekNo == weekNo).ToList();
            var qtmData = db.QTMData.Where(r => r.WeekNo == weekNo).ToList();
            var visualData = db.VisualData.Where(r => r.WeekNo == weekNo).ToList();
            var frecuency = (int)db.SelfControlSpecs.Where(s => s.Descripcion == "Frecuency").Select(s => s.Value).FirstOrDefault();
            
            // Weekly Day's resume
            foreach (var item in listDays)
            {
                SelfControlReportList element = new SelfControlReportList();
                element.DayofWeek = item.Day;
                element.Date = item.Date;

                List<SelfControlByShift> shifts = new List<SelfControlByShift>();
                foreach (var workCenter in listWorkCenters)
                {
                    element.Item = workCenter;
                    foreach (var _shift in listShifts)
                    {
                        SelfControlByShift shift = new SelfControlByShift();
                        shift.Item = _shift;

                        var parameterQ = (int)(qtmData.Where(q => (q.IdWorkCenter == workCenter) && (q.DateBegin == item.Date) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                        var parameterV = (int)(visualData.Where(q => (q.IdWorkCenter == workCenter) && (q.DateBegin == item.Date)).Select(q => q.Value).Sum());

                        var listMaker = rtData
                            .Where(x => (x.IdWorkCenter == workCenter) && (item.Date >= x.BeginTime && item.Date <= x.EndTime) && (x.Type == "Maker") && (x.Shift == _shift))
                            .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                            {
                                ItemName = workCenter,
                                Parameter = parameterQ,
                                Sampling = (cant.Sum() / 60) / frecuency,
                                WorkingTime = (cant.Sum() / 60),
                                Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : (parameterQ * 100) / ((cant.Sum() / 60) / frecuency)
                            }).FirstOrDefault();

                        var listPacker = rtData
                                .Where(x => (x.IdWorkCenter == workCenter) && (item.Date >= x.BeginTime && item.Date <= x.EndTime) && (x.Type == "Packer") && (x.Shift == _shift))
                                .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                                {
                                    ItemName = workCenter,
                                    Parameter = parameterV,
                                    Sampling = (cant.Sum() / 60) / frecuency,
                                    WorkingTime = (cant.Sum() / 60),
                                    Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : (parameterV * 100) / ((cant.Sum() / 60) / frecuency)
                                }).FirstOrDefault();

                        shift.Physical = new SelfControlReportView();
                        shift.Physical = listMaker;
                        shift.Visual = new SelfControlReportView();
                        shift.Visual = listPacker;

                        shifts.Add(shift);
                    }
                }
                element.Shift = new List<SelfControlByShift>();
                element.Shift = shifts;

                lists.Add(element);
            }
            // Weekly resume
            foreach (var workCenter in listWorkCenters)
            {
                SelfControlReportList wList = new SelfControlReportList();
                wList.Item = workCenter;
                wList.DayofWeek = "Resumen Semanal";
                wList.Date = listDays[0].Date;

                List<SelfControlByShift> shifts = new List<SelfControlByShift>();

                foreach (var _shift in listShifts)
                {
                    SelfControlByShift shift = new SelfControlByShift();
                    shift.Item = _shift;

                    var parameterQ = (int)(qtmData.Where(q => (q.IdWorkCenter == workCenter) && (q.Shift == _shift)).Select(q => q.Value).Sum());
                    var parameterV = (int)(visualData.Where(q => (q.IdWorkCenter == workCenter) && (q.Shift == _shift)).Select(q => q.Value).Sum());

                    var listMaker = rtData
                        .Where(x => (x.IdWorkCenter == workCenter) && (x.Type == "Maker") && (x.Shift == _shift))
                        .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                        {
                            ItemName = workCenter,
                            Parameter = parameterQ,
                            Sampling = (cant.Sum() / 60) / frecuency,
                            WorkingTime = (cant.Sum() / 60),
                            Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : (parameterQ * 100) / ((cant.Sum() / 60) / frecuency)
                        }).FirstOrDefault();

                    var listPacker = rtData
                            .Where(x => (x.IdWorkCenter == workCenter) && (x.Type == "Packer") && (x.Shift == _shift))
                            .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                            {
                                ItemName = workCenter,
                                Parameter = parameterV,
                                Sampling = (cant.Sum() / 60) / frecuency,
                                WorkingTime = (cant.Sum() / 60),
                                Fulfillment = ((cant.Sum() / 60) / frecuency) == 0 ? 0 : (parameterV * 100) / ((cant.Sum() / 60) / frecuency)
                            }).FirstOrDefault();

                    shift.Physical = new SelfControlReportView();
                    shift.Physical = listMaker;
                    shift.Visual = new SelfControlReportView();
                    shift.Visual = listPacker;

                    shifts.Add(shift);
                }

                wList.Shift = shifts;
                lists.Add(wList);
            }

            return Json(new { lists }, JsonRequestBehavior.AllowGet);
        }


        // GET: Secondary/WorkCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secondary/WorkCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Facility,Company,Active")] WorkCenter workCenter)
        {
            if (ModelState.IsValid)
            {
                db.WorkCenters.Add(workCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workCenter);
        }

        // GET: Secondary/WorkCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenters.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        // POST: Secondary/WorkCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Facility,Company,Active")] WorkCenter workCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workCenter);
        }

        // GET: Secondary/WorkCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCenter workCenter = db.WorkCenters.Find(id);
            if (workCenter == null)
            {
                return HttpNotFound();
            }
            return View(workCenter);
        }

        // POST: Secondary/WorkCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkCenter workCenter = db.WorkCenters.Find(id);
            db.WorkCenters.Remove(workCenter);
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
