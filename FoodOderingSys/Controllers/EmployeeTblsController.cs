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
    public class EmployeeTblsController : Controller
    {
        private FoodOrderingProjectEntitiesEmp db = new FoodOrderingProjectEntitiesEmp();

        // GET: EmployeeTbls
        public ActionResult Index()
        {
            if (Session["Ownername"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.EmployeeTbls.ToList());
        }

        // GET: EmployeeTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
            if (employeeTbl == null)
            {
                return HttpNotFound();
            }
            return View(employeeTbl);
        }

        // GET: EmployeeTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeInfoID,EmployeeName,EmployeeAddress,EmployeeContactNo,EmployeeDesignation")] EmployeeTbl employeeTbl)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTbls.Add(employeeTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeTbl);
        }

        // GET: EmployeeTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
            if (employeeTbl == null)
            {
                return HttpNotFound();
            }
            return View(employeeTbl);
        }

        // POST: EmployeeTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeInfoID,EmployeeName,EmployeeAddress,EmployeeContactNo,EmployeeDesignation")] EmployeeTbl employeeTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeTbl);
        }

        // GET: EmployeeTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
            if (employeeTbl == null)
            {
                return HttpNotFound();
            }
            return View(employeeTbl);
        }

        // POST: EmployeeTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTbl employeeTbl = db.EmployeeTbls.Find(id);
            db.EmployeeTbls.Remove(employeeTbl);
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
