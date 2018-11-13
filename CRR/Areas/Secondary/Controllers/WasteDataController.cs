using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Models.Entidades;
using CRR.Models.Vistas;
using CRR.Models.Vistas.CRR;
using CRR.Helpers;
using CRR.Services;
using Microsoft.AspNet.Identity;
using CRR.Models.RespuestaGenerica;
using CRR.Models.Entidades.Admin;

namespace CRR.Areas.Secondary.Controllers
{
    public class WasteDataController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/WasteData
        public ActionResult Index()
        {
            return View(db.WasteData.ToList());
        }

        // GET: Secondary/WasteData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteData wasteData = db.WasteData.Find(id);
            if (wasteData == null)
            {
                return HttpNotFound();
            }
            return View(wasteData);
        }

        // GET: Secondary/WasteData/Create
        public ActionResult Create()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            List<String> listWC = db.FastShiftData.Where(fsd => fsd.RegistrationDate == today).Select(fsd => fsd.IdWorkcenter).ToList();
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.Where(w => listWC.Contains(w.Name)).OrderBy(x => x.Name), "Name", "Name");
            return View();
        }

        // POST: Secondary/WasteData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WasteData wasteData, string orderNo, string codeFA, string Operator)
        {
            if (ModelState.IsValid)
            {
                var order = (orderNo == null || orderNo == "")
                    ? db.FastShiftData.Where(f => f.IdWorkcenter == wasteData.IdWorkCenter).OrderByDescending(f => f.RegistrationDate).Select(f => f.OrderNo).FirstOrDefault()
                    : Int32.Parse(orderNo);
                ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Name", "Name", wasteData.IdWorkCenter);
                wasteData.Shift = Shift.Get();
                wasteData.IdBrand = (codeFA == null || codeFA == "")
                    ? db.FastShiftData.Where(f => f.IdWorkcenter == wasteData.IdWorkCenter && f.OrderStatus == 2).OrderByDescending(f => f.RegistrationDate).Select(f => f.IdBrand).FirstOrDefault()
                    : codeFA;
                wasteData.CigaretteWeight = CigaretteSpecificationsServices.getCigaretteWeigth(order.ToString()) == 0 
                    ? db.Brands.Where(b => b.CodeFA == wasteData.IdBrand).Select(b => b.CigaretteWeight).FirstOrDefault()
                    : CigaretteSpecificationsServices.getCigaretteWeigth(order.ToString());
                wasteData.CigaretteWaste = Double.IsInfinity(wasteData.VolumeWaste / wasteData.CigaretteWeight) ? 0 : wasteData.VolumeWaste / wasteData.CigaretteWeight;
                wasteData.RegistrationDate = DateTime.Now;
                IRespuestaServicio<User> user = UserServices.GetUser(User.Identity.GetUserId());
                wasteData.IdUser = user.Respuesta.UserName;

                db.WasteData.Add(wasteData);
                db.SaveChanges();

                bool label = CigaretteSpecificationsServices.addLabel(order.ToString(), wasteData, Operator);

                return RedirectToAction("Index", "Labels", new { area = "Secondary" });
            }

            return View(wasteData);
        }

        // GET: Secondary/WasteData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteData wasteData = db.WasteData.Find(id);
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Id", "Name");

            if (wasteData == null)
            {
                return HttpNotFound();
            }
            return View(wasteData);
        }

        // POST: Secondary/WasteData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WasteData wasteData)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Id", "Nombre", wasteData.IdWorkCenter);
                db.Entry(wasteData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wasteData);
        }

        [HttpPost]
        public ActionResult Report(DateTime dateBegin, DateTime dateEnd)
        {
            IList<CRRByDepartment> listadelistas = new List<CRRByDepartment>();
            dateEnd = dateEnd.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (FastShiftDataServices.GetData(dateBegin, dateEnd))
            {
                var departments = db.Departments.ToList();
                var wasteCRR = db.WasteData.Where(x => (x.RegistrationDate >= dateBegin && x.RegistrationDate <= dateEnd)).ToList();
                var FastShiftData = db.FastShiftData.Where(x => (x.RegistrationDate >= dateBegin && x.RegistrationDate <= dateEnd)).ToList();
                var specsCRR = db.WasteDepartments.ToList();

                foreach (var item in departments)
                {
                    CRRByDepartment crrByDepartment = new CRRByDepartment();
                    crrByDepartment.Department = item;
                    crrByDepartment.dateBegin = dateBegin;
                    crrByDepartment.dateEnd = dateEnd;

                    var workCenters = db.WorkCenters.Where(w => w.DepartmentName == item.Name).ToList();
                    
                        double? totalWaste = 0;

                        foreach (var wItem in workCenters)
                        {
                            totalWaste = totalWaste + wasteCRR.Where(f => f.IdWorkCenter == wItem.Name).Select(f => f.CigaretteWaste).Sum();// Cigarrillos
                        }

                        var values = FastShiftData
                            .Where(x => (x.IdDepartment == item.Name))
                            .GroupBy(rd => rd.IdDepartment, rd => rd.TargetQty, (code, cant) => new CRRReportView
                            {
                                CRR = Double.IsNaN((double)totalWaste / ((double)totalWaste + cant.Sum())) ? 0 : Math.Round((double)totalWaste / ((double)totalWaste + cant.Sum()), 3),
                                VolumenProduccion = Math.Round(cant.Sum(), 3),
                                VolumenWaste = Math.Round((double)totalWaste, 2),
                                Specs = specsCRR.Where(s => s.IdDepartment == code).Select(s => s.Value).FirstOrDefault(),
                                PorcentajeVolumen = Math.Round(cant.Sum() * 100 / FastShiftData.Where(f => f.IdDepartment == item.Name).Select(f => f.ProdVol).Sum(), 0)
                            }).ToList();

                        if (values.Count() != 0)
                        {
                            crrByDepartment.Values = new List<CRRReportView>();
                            crrByDepartment.Values = values;

                            listadelistas.Add(crrByDepartment);
                        }
                    
                }
            }
            
            return PartialView(listadelistas);
        }

        [RenderAjaxPartialScripts]
        public ActionResult Parametros(DateTime? dateBegin, DateTime? dateEnd)
        {
            if(dateBegin == null )
            {
                dateBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
            }

            var workCenters = db.WorkCenters.ToList();
            var wasteCRR = db.WasteData.Where(x => (x.RegistrationDate >= dateBegin && x.RegistrationDate <= dateEnd)).ToList();
            var FastShiftData = db.FastShiftData.Where(x => (x.RegistrationDate >= dateBegin && x.RegistrationDate <= dateEnd)).ToList();
            var specsCRR = db.WasteWorkCenters.ToList();

            IList<CRRReportView> lists = new List<CRRReportView>();
            foreach (var item in workCenters)
            {
                var faWC = FastShiftData.Where(fsd => fsd.IdWorkcenter == item.Name).Select(fsd => fsd.IdBrand);

                foreach (var faCode in faWC)
                {
                    var totalWaste = Math.Round(wasteCRR.Where(v => (v.IdWorkCenter == item.Name && v.IdBrand == faCode)).Select(v => v.CigaretteWaste).Sum(),2);

                    var list = FastShiftData
                        .Where(x => (x.IdWorkcenter == item.Name && x.IdBrand == faCode))
                        .GroupBy(rd => rd.IdBrand, rd => rd.TargetQty, (fa, cant) => new CRRReportView
                        {
                            ItemName = item.Name,
                            FAName = fa,
                            VolumenProduccion = Math.Round(cant.Sum(), 2),
                            CRR = Double.IsNaN(totalWaste /(totalWaste + cant.Sum())) ? 0 : Math.Round(totalWaste / (totalWaste + cant.Sum()),3),
                            VolumenWaste = totalWaste,
                            Specs = specsCRR.Where(s => s.IdWorkCenter == item.Name).Select(s => s.Value).FirstOrDefault()
                        }).FirstOrDefault();

                    if (list != null)
                        lists.Add(list);
                }
            }

            return Json(new { lists }, JsonRequestBehavior.AllowGet);
        }

        // GET: Secondary/WasteData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteData wasteData = db.WasteData.Find(id);
            if (wasteData == null)
            {
                return HttpNotFound();
            }
            return View(wasteData);
        }

        // POST: Secondary/WasteData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WasteData wasteData = db.WasteData.Find(id);
            db.WasteData.Remove(wasteData);
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
