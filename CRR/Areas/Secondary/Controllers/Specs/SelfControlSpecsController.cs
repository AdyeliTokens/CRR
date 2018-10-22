using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Helpers;
using CRR.Models.Entidades.Specs;
using CRR.Models.Vistas.CRR;
using CRR.Models.Vistas.Helpers;
using CRR.Models.Vistas.SelfControl;
using CRR.Services;

namespace CRR.Areas.Secondary.Controllers.Specs
{
    public class SelfControlSpecsController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/SelfControlSpecs
        public ActionResult Index()
        {
           return View(db.SelfControlSpecs.ToList());
        }

        // GET: Secondary/SelfControlSpecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfControlSpecs selfControlSpecs = db.SelfControlSpecs.Find(id);
            if (selfControlSpecs == null)
            {
                return HttpNotFound();
            }
            return View(selfControlSpecs);
        }

        // GET: Secondary/SelfControlSpecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secondary/SelfControlSpecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Value,UM,Active")] SelfControlSpecs selfControlSpecs)
        {
            if (ModelState.IsValid)
            {
                db.SelfControlSpecs.Add(selfControlSpecs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selfControlSpecs);
        }

        // GET: Secondary/SelfControlSpecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfControlSpecs selfControlSpecs = db.SelfControlSpecs.Find(id);
            if (selfControlSpecs == null)
            {
                return HttpNotFound();
            }
            return View(selfControlSpecs);
        }


        [HttpPost]
        public ActionResult Report(int weekNo)
        {
            Parameters parameter = new Parameters();
            parameter.weekNo = weekNo;

            try
            {
                var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                if (weekNo == currentWeek || weekNo == 0)
                {
                    var WeekNumber = weekNo == 0 ? currentWeek : weekNo;
                    parameter.weekNo = WeekNumber;

                    var dateBegin = Week.FirstDateOfWeekISO8601(DateTime.Now.Year, WeekNumber);
                    var dateEnd = dateBegin.AddDays(6);

                    SelfControlDataServices.GetRunningTimeData(dateBegin, dateEnd);
                    SelfControlDataServices.GetQTMData(dateBegin, dateEnd);
                    SelfControlDataServices.GetVisualData(dateBegin, dateEnd);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return PartialView(parameter);
        }

        [RenderAjaxPartialScripts]
        public ActionResult PhysicalParameters(int weekNo)
        {
            var workCenters  = db.WorkCenters.ToList();
            var rtData       = db.RunningTimeData.OrderBy(r => r.IdWorkCenter).Where(r=> r.WeekNo == weekNo).ToList();
            var qtmData      = db.QTMData.OrderBy(r => r.IdWorkCenter).Where(r => r.WeekNo == weekNo).ToList();
            var frecuency    = (int) db.SelfControlSpecs.Where(s => s.Descripcion == "Frecuency").Select(s => s.Value).FirstOrDefault();

            IList<SelfControlReportView> lists = new List<SelfControlReportView>();
            foreach (var item in workCenters)
            {
                var parameter = qtmData.Where(q => q.IdWorkCenter == item.Name).Select(q => q.Value).Sum();
                var list = rtData
                    .Where(x => (x.IdWorkCenter == item.Name))
                    .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                    {
                        ItemName            = item.Name,
                        Parameter           = parameter,
                        Sampling            = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum() / 60) / frecuency,
                        WorkingTime         = (cant.Sum() / 60),
                        Fulfillment         = ( ((cant.Sum() / 60) / frecuency) == 0 || parameter == 0 ) ? 0 : (parameter*100) / ((cant.Sum() / 60) / frecuency)
                    }).FirstOrDefault();

                if (list != null)
                    lists.Add(list);
            }

            return Json(new { lists }, JsonRequestBehavior.AllowGet);
        }
    
        [RenderAjaxPartialScripts]
        public ActionResult VisualParameters(int weekNo)
        {
            var workCenters = db.WorkCenters.ToList();
            var rtData = db.RunningTimeData.OrderBy(r=> r.IdWorkCenter).Where(r => r.WeekNo == weekNo).ToList();
            var visualData = db.VisualData.OrderBy(r => r.IdWorkCenter).Where(r => r.WeekNo == weekNo).ToList();
            var frecuency = (int)db.SelfControlSpecs.Where(s => s.Descripcion == "Frecuency").Select(s => s.Value).FirstOrDefault();

            IList<SelfControlReportView> lists = new List<SelfControlReportView>();
            foreach (var item in workCenters)
            {
                var parameter = visualData.Where(q => q.IdWorkCenter == item.Name).Select(q => q.Value).Sum();

                var list = rtData
                   .Where(x => (x.IdWorkCenter == item.Name))
                   .GroupBy(rd => rd.IdWorkCenter, rd => rd.RunningTime, (id, cant) => new SelfControlReportView
                   {
                       ItemName = item.Name,
                       Parameter = parameter,
                       Sampling = (cant.Sum() / 60) == 0 ? 0 : (cant.Sum()/60) / frecuency,
                       WorkingTime = (cant.Sum() / 60) == 0 ? 0 : cant.Sum()/60,
                       Fulfillment = (cant.Sum() / 60 == 0 || parameter ==0 ) ? 0 : (parameter * 100) / ((cant.Sum() / 60) / frecuency)
                   }).FirstOrDefault();

                if (list != null)
                    lists.Add(list);
            }

            return Json(new { lists }, JsonRequestBehavior.AllowGet);
        }

        // POST: Secondary/SelfControlSpecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Value,UM,Active")] SelfControlSpecs selfControlSpecs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selfControlSpecs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(selfControlSpecs);
        }

        // GET: Secondary/SelfControlSpecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelfControlSpecs selfControlSpecs = db.SelfControlSpecs.Find(id);
            if (selfControlSpecs == null)
            {
                return HttpNotFound();
            }
            return View(selfControlSpecs);
        }

        // POST: Secondary/SelfControlSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelfControlSpecs selfControlSpecs = db.SelfControlSpecs.Find(id);
            db.SelfControlSpecs.Remove(selfControlSpecs);
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
