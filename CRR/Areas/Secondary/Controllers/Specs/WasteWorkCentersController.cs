using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Models.Entidades.Specs;

namespace CRR.Areas.Secondary.Controllers.Specs
{
    public class WasteWorkCentersController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/WasteWorkCenters
        public ActionResult Index()
        {
            var list = db.WasteWorkCenters.Include(w => w.WorkCenter);
            return View(list.ToList());
        }

        // GET: Secondary/WasteWorkCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteWorkCenter wasteWorkCenter = db.WasteWorkCenters.Find(id);
            if (wasteWorkCenter == null)
            {
                return HttpNotFound();
            }
            return View(wasteWorkCenter);
        }

        // GET: Secondary/WasteWorkCenters/Create
        public ActionResult Create()
        {
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Name", "Name");
            return View();
        }

        // POST: Secondary/WasteWorkCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WasteWorkCenter wasteWorkCenter)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Name", "Nombre", wasteWorkCenter.IdWorkCenter);
                db.WasteWorkCenters.Add(wasteWorkCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wasteWorkCenter);
        }

        // GET: Secondary/WasteWorkCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteWorkCenter wasteWorkCenter = db.WasteWorkCenters.Find(id);
            ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Name", "Name", wasteWorkCenter.IdWorkCenter);
            if (wasteWorkCenter == null)
            {
                return HttpNotFound();
            }
            return View(wasteWorkCenter);
        }

        // POST: Secondary/WasteWorkCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WasteWorkCenter wasteWorkCenter)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IdWorkCenter = new SelectList(db.WorkCenters.OrderBy(x => x.Name), "Name", "Name", wasteWorkCenter.IdWorkCenter);
                db.Entry(wasteWorkCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wasteWorkCenter);
        }

        // GET: Secondary/WasteWorkCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteWorkCenter wasteWorkCenter = db.WasteWorkCenters.Find(id);
            if (wasteWorkCenter == null)
            {
                return HttpNotFound();
            }
            return View(wasteWorkCenter);
        }

        // POST: Secondary/WasteWorkCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WasteWorkCenter wasteWorkCenter = db.WasteWorkCenters.Find(id);
            db.WasteWorkCenters.Remove(wasteWorkCenter);
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
