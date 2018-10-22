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
    public class WasteDepartmentsController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/WasteDepartments
        public ActionResult Index()
        {
            var wasteDepartments = db.WasteDepartments.Include(o => o.Department);
            return View(wasteDepartments.ToList());
        }

        // GET: Secondary/WasteDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteDepartment wasteDepartment = db.WasteDepartments.Find(id);
            if (wasteDepartment == null)
            {
                return HttpNotFound();
            }
            return View(wasteDepartment);
        }

        // GET: Secondary/WasteDepartments/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartment = new SelectList(db.Departments.OrderBy(x => x.Name), "Name", "Name");
            return View();
        }

        // POST: Secondary/WasteDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( WasteDepartment wasteDepartment)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IdDepartment = new SelectList(db.Departments.OrderBy(x => x.Name), "Name", "Name", wasteDepartment.IdDepartment);
                db.WasteDepartments.Add(wasteDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wasteDepartment);
        }

        // GET: Secondary/WasteDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteDepartment wasteDepartment = db.WasteDepartments.Find(id);
            if (wasteDepartment == null)
            {
                return HttpNotFound();
            }
            return View(wasteDepartment);
        }

        // POST: Secondary/WasteDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( WasteDepartment wasteDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wasteDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wasteDepartment);
        }

        // GET: Secondary/WasteDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteDepartment wasteDepartment = db.WasteDepartments.Find(id);
            if (wasteDepartment == null)
            {
                return HttpNotFound();
            }
            return View(wasteDepartment);
        }

        // POST: Secondary/WasteDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WasteDepartment wasteDepartment = db.WasteDepartments.Find(id);
            db.WasteDepartments.Remove(wasteDepartment);
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
