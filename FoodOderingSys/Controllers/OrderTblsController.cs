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
    public class OrderTblsController : Controller
    {
        private FoodOrderingProjectEntitiesCat db = new FoodOrderingProjectEntitiesCat();

        // GET: OrderTbls
        public ActionResult Index()
        {
            var orderTbls = db.OrderTbls.Include(o => o.CustomerTbl).Include(o => o.ProductTbl).Include(o => o.ProductTbl1);
            return View(orderTbls.ToList());
        }

        // GET: OrderTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTbl orderTbl = db.OrderTbls.Find(id);
            if (orderTbl == null)
            {
                return HttpNotFound();
            }
            return View(orderTbl);
        }

        // GET: OrderTbls/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.CustomerTbls, "CustomerID", "CustomerName");
            ViewBag.ProductID = new SelectList(db.ProductTbls, "ProductID", "ProductName");
            ViewBag.ProductPrice = new SelectList(db.ProductTbls, "ProductID", "ProductPrice");
            return View();
        }

        // POST: OrderTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDate,CustomerID,Qnty,ProductID,ProductPrice,TotalBill")] OrderTbl orderTbl)
        {
            if (ModelState.IsValid)
            {
                db.OrderTbls.Add(orderTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.CustomerTbls, "CustomerID", "CustomerName", orderTbl.CustomerID);
            ViewBag.ProductID = new SelectList(db.ProductTbls, "ProductID", "ProductName", orderTbl.ProductID);
            ViewBag.ProductPrice = new SelectList(db.ProductTbls, "ProductID", "ProductPrice", orderTbl.ProductPrice);
            return View(orderTbl);
        }

        // GET: OrderTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTbl orderTbl = db.OrderTbls.Find(id);
            if (orderTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.CustomerTbls, "CustomerID", "CustomerName", orderTbl.CustomerID);
            ViewBag.ProductID = new SelectList(db.ProductTbls, "ProductID", "ProductName", orderTbl.ProductID);
            ViewBag.ProductPrice = new SelectList(db.ProductTbls, "ProductID", "ProductName", orderTbl.ProductPrice);
            return View(orderTbl);
        }

        // POST: OrderTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,CustomerID,Qnty,ProductID,ProductPrice,TotalBill")] OrderTbl orderTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.CustomerTbls, "CustomerID", "CustomerName", orderTbl.CustomerID);
            ViewBag.ProductID = new SelectList(db.ProductTbls, "ProductID", "ProductName", orderTbl.ProductID);
            ViewBag.ProductPrice = new SelectList(db.ProductTbls, "ProductID", "ProductName", orderTbl.ProductPrice);
            return View(orderTbl);
        }

        // GET: OrderTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTbl orderTbl = db.OrderTbls.Find(id);
            if (orderTbl == null)
            {
                return HttpNotFound();
            }
            return View(orderTbl);
        }

        // POST: OrderTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderTbl orderTbl = db.OrderTbls.Find(id);
            db.OrderTbls.Remove(orderTbl);
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
