﻿using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PublishersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publishers
        public ActionResult Index()
        {
            return View(db.Publishers
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Location)
                .ToList());
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return Json(new { isSuccessful = false }, JsonRequestBehavior.AllowGet);
            }
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return Json(new { isSuccessful = true }, JsonRequestBehavior.AllowGet);
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
