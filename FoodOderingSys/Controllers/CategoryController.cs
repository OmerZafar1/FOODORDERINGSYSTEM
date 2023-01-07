using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodOderingSys.Models;

namespace FoodOderingSys.Controllers
{
    public class CategoryController : Controller
    {
        private FoodOrderingProjectEntitiesCat db = new FoodOrderingProjectEntitiesCat();

        // GET: Category
        public ActionResult Index()
        {
            if (Session["Ownername"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.CategoryTbls.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTbls.Add(categoryTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryTbl);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryTbl);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            db.CategoryTbls.Remove(categoryTbl);
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
