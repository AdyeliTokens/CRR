using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRR.DAL;
using CRR.Helpers;
using CRR.Models.Entidades.Specs;
using PdfSharp.Pdf;

namespace CRR.Areas.Secondary.Controllers.Specs
{
    public class LabelsController : Controller
    {
        private CRRContext db = new CRRContext();

        // GET: Secondary/Labels
        public ActionResult Index()
        {
            var label = db.Label.OrderByDescending(l=> l.Id).Include(l => l.Waste);
            return View(label.ToList());
        }

        // GET: Secondary/Labels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = db.Label.Find(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        // GET: Secondary/Labels/Print/5
        public void Print(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Label label = db.Label.Find(id);
            //if (label == null)
            //{
            //    return HttpNotFound();
            //}

            PdfDocument document = new PdfDocument();
            document = PrintLabel.CreateDocument(label);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, false);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            stream.Close();
            Response.End();

            //return View(label);
        }
        
        // GET: Secondary/Labels/Create
        public ActionResult Create()
        {
            ViewBag.IdWaste = new SelectList(db.WasteData, "Id", "IdWorkCenter");
            return View();
        }

        // POST: Secondary/Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Label label)
        {
            if (ModelState.IsValid)
            {
                db.Label.Add(label);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdWaste = new SelectList(db.WasteData, "Id", "IdWorkCenter", label.IdWaste);
            return View(label);
        }

        // GET: Secondary/Labels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = db.Label.Find(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdWaste = new SelectList(db.WasteData, "Id", "IdWorkCenter", label.IdWaste);
            return View(label);
        }

        // POST: Secondary/Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Label label)
        {
            if (ModelState.IsValid)
            {
                db.Entry(label).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdWaste = new SelectList(db.WasteData, "Id", "IdWorkCenter", label.IdWaste);
            return View(label);
        }

        // GET: Secondary/Labels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Label label = db.Label.Find(id);
            if (label == null)
            {
                return HttpNotFound();
            }
            return View(label);
        }

        // POST: Secondary/Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Label label = db.Label.Find(id);
            db.Label.Remove(label);
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
