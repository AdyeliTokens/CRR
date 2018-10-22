using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Models.Entidades.SelfControl;

namespace CRR.Areas.Secondary.Controllers.SelfControl
{
    public class RunningTimeDataController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/RunningTimeData
        public ActionResult Index()
        {
            var runningTimeData = db.RunningTimeData.Include(r => r.WorkCenter);
            return View(runningTimeData.ToList());
        }

        // GET: Secondary/RunningTimeData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningTimeData runningTimeData = db.RunningTimeData.Find(id);
            if (runningTimeData == null)
            {
                return HttpNotFound();
            }
            return View(runningTimeData);
        }

        // GET: Secondary/RunningTimeData/Create
        public ActionResult Create()
        {
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility");
            return View();
        }

        // POST: Secondary/RunningTimeData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdWorkCenter,Type,RunningTime,Shift,ShiftName,WeekNo,BeginTime,EndTime")] RunningTimeData runningTimeData)
        {
            if (ModelState.IsValid)
            {
                db.RunningTimeData.Add(runningTimeData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", runningTimeData.IdWorkCenter);
            return View(runningTimeData);
        }

        // GET: Secondary/RunningTimeData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningTimeData runningTimeData = db.RunningTimeData.Find(id);
            if (runningTimeData == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", runningTimeData.IdWorkCenter);
            return View(runningTimeData);
        }

        // POST: Secondary/RunningTimeData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdWorkCenter,Type,RunningTime,Shift,ShiftName,WeekNo,BeginTime,EndTime")] RunningTimeData runningTimeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runningTimeData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", runningTimeData.IdWorkCenter);
            return View(runningTimeData);
        }

        // GET: Secondary/RunningTimeData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningTimeData runningTimeData = db.RunningTimeData.Find(id);
            if (runningTimeData == null)
            {
                return HttpNotFound();
            }
            return View(runningTimeData);
        }

        // POST: Secondary/RunningTimeData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RunningTimeData runningTimeData = db.RunningTimeData.Find(id);
            db.RunningTimeData.Remove(runningTimeData);
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
