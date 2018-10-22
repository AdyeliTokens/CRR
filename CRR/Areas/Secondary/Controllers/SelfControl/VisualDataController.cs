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
    public class VisualDataController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/VisualData
        public ActionResult Index()
        {
            var visualData = db.VisualData.Include(v => v.WorkCenter);
            return View(visualData.ToList());
        }

        // GET: Secondary/VisualData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualData visualData = db.VisualData.Find(id);
            if (visualData == null)
            {
                return HttpNotFound();
            }
            return View(visualData);
        }

        // GET: Secondary/VisualData/Create
        public ActionResult Create()
        {
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility");
            return View();
        }

        // POST: Secondary/VisualData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdWorkCenter,Value,WeekNo,DateBegin,DateEnd")] VisualData visualData)
        {
            if (ModelState.IsValid)
            {
                db.VisualData.Add(visualData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", visualData.IdWorkCenter);
            return View(visualData);
        }

        // GET: Secondary/VisualData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualData visualData = db.VisualData.Find(id);
            if (visualData == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", visualData.IdWorkCenter);
            return View(visualData);
        }

        // POST: Secondary/VisualData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdWorkCenter,Value,WeekNo,DateBegin,DateEnd")] VisualData visualData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visualData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters, "Name", "Facility", visualData.IdWorkCenter);
            return View(visualData);
        }

        // GET: Secondary/VisualData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualData visualData = db.VisualData.Find(id);
            if (visualData == null)
            {
                return HttpNotFound();
            }
            return View(visualData);
        }

        // POST: Secondary/VisualData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisualData visualData = db.VisualData.Find(id);
            db.VisualData.Remove(visualData);
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
