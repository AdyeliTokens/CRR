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
    public class QTMDataController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/QTMData
        public ActionResult Index()
        {
            var qTMData = db.QTMData.Include(q => q.WorkCenter);
            return View(qTMData.ToList());
        }

        // GET: Secondary/QTMData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTMData qTMData = db.QTMData.Find(id);
            if (qTMData == null)
            {
                return HttpNotFound();
            }
            return View(qTMData);
        }

        // GET: Secondary/QTMData/Create
        public ActionResult Create()
        {
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility");
            return View();
        }

        // POST: Secondary/QTMData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdWorkCenter,Value,WeekNo,DateBegin,DateEnd")] QTMData qTMData)
        {
            if (ModelState.IsValid)
            {
                db.QTMData.Add(qTMData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", qTMData.IdWorkCenter);
            return View(qTMData);
        }

        // GET: Secondary/QTMData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTMData qTMData = db.QTMData.Find(id);
            if (qTMData == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", qTMData.IdWorkCenter);
            return View(qTMData);
        }

        // POST: Secondary/QTMData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdWorkCenter,Value,WeekNo,DateBegin,DateEnd")] QTMData qTMData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qTMData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", qTMData.IdWorkCenter);
            return View(qTMData);
        }

        // GET: Secondary/QTMData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTMData qTMData = db.QTMData.Find(id);
            if (qTMData == null)
            {
                return HttpNotFound();
            }
            return View(qTMData);
        }

        // POST: Secondary/QTMData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QTMData qTMData = db.QTMData.Find(id);
            db.QTMData.Remove(qTMData);
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
