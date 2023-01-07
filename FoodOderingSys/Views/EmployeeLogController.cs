using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodOderingSys.Models;

namespace FoodOderingSys.Views
{
    public class EmployeeLogController : Controller
    {
        private FoodOrderingProjectEntitiesEmp db = new FoodOrderingProjectEntitiesEmp();

        // GET: EmployeeLog
        public ActionResult Index()
        {
            if (Session["Ownername"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.EmployeeLogins.ToList());
        }

        // GET: EmployeeLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // GET: EmployeeLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeLoginID,EmployeeEmail,EmployeePassword,EmployeeInfoID")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLogins.Add(employeeLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeLogin);
        }

        // GET: EmployeeLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // POST: EmployeeLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeLoginID,EmployeeEmail,EmployeePassword,EmployeeInfoID")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeLogin);
        }

        // GET: EmployeeLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            if (employeeLogin == null)
            {
                return HttpNotFound();
            }
            return View(employeeLogin);
        }

        // POST: EmployeeLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(id);
            db.EmployeeLogins.Remove(employeeLogin);
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
