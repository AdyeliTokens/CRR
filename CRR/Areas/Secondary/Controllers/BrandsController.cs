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
    public class BrandsController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/Brands
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: Secondary/Brands/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Secondary/Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secondary/Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Secondary/Brands/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Secondary/Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Secondary/Brands/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Secondary/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetListCodeFA(string IdWorkCenter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var ctx = new CRRStoredProcedures())
                    {
                        var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                        var lista = ctx.CRR_ProcessOrderList(today, today.AddDays(-7), IdWorkCenter).Select(p => new { p.OrderNo, p.Brand }).ToList();
                        return Json(new { lista }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException);
                    return Json(new { status = 400 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = 400 }, JsonRequestBehavior.AllowGet);
            }
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
