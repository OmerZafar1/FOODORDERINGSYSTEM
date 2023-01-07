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
    public class CustomerController : Controller
    {
        private FoodOrderingProjectEntities3 db = new FoodOrderingProjectEntities3();

        // GET: Customer
        public ActionResult Index()
        {
            if (Session["Ownername"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.CustomerTbls.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTbl customerTbl = db.CustomerTbls.Find(id);
            if (customerTbl == null)
            {
                return HttpNotFound();
            }
            return View(customerTbl);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,CustomerAddress,CustomerPhoneNo")] CustomerTbl customerTbl)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTbls.Add(customerTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerTbl);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTbl customerTbl = db.CustomerTbls.Find(id);
            if (customerTbl == null)
            {
                return HttpNotFound();
            }
            return View(customerTbl);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,CustomerAddress,CustomerPhoneNo")] CustomerTbl customerTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerTbl);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTbl customerTbl = db.CustomerTbls.Find(id);
            if (customerTbl == null)
            {
                return HttpNotFound();
            }
            return View(customerTbl);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerTbl customerTbl = db.CustomerTbls.Find(id);
            db.CustomerTbls.Remove(customerTbl);
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
