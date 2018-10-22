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
using CRR.Models.Stored_Procedures;

namespace CRR.Areas.Secondary.Controllers
{
    public class FastShiftDataController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/FastShiftData
        public ActionResult Index()
        {
            return View(db.FastShiftData.ToList());
        }

        // GET: Secondary/FastShiftData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FastShiftData fastShiftData = db.FastShiftData.Find(id);
            if (fastShiftData == null)
            {
                return HttpNotFound();
            }
            return View(fastShiftData);
        }

        // GET: Secondary/FastShiftData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secondary/FastShiftData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FastShiftData fastShiftData)
        {
            if (ModelState.IsValid)
            {
                db.FastShiftData.Add(fastShiftData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fastShiftData);
        }

        // GET: Secondary/FastShiftData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FastShiftData fastShiftData = db.FastShiftData.Find(id);
            if (fastShiftData == null)
            {
                return HttpNotFound();
            }
            return View(fastShiftData);
        }

        // POST: Secondary/FastShiftData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FastShiftData fastShiftData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fastShiftData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fastShiftData);
        }

        // GET: Secondary/FastShiftData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FastShiftData fastShiftData = db.FastShiftData.Find(id);
            if (fastShiftData == null)
            {
                return HttpNotFound();
            }
            return View(fastShiftData);
        }

        // POST: Secondary/FastShiftData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FastShiftData fastShiftData = db.FastShiftData.Find(id);
            db.FastShiftData.Remove(fastShiftData);
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
