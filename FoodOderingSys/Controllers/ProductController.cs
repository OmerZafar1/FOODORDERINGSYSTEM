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
    public class ProductController : Controller
    {
        private FoodOrderingProjectEntitiesCat db = new FoodOrderingProjectEntitiesCat();

        // GET: Product
        public ActionResult Index()
        {
            if (Session["Ownername"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var productTbls = db.ProductTbls.Include(p => p.CategoryTbl);
            return View(productTbls.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductPrice,CategoryID")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProductTbls.Add(productTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductPrice,CategoryID")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTbls, "CategoryID", "CategoryName", productTbl.CategoryID);
            return View(productTbl);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTbl productTbl = db.ProductTbls.Find(id);
            db.ProductTbls.Remove(productTbl);
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
