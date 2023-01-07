using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOderingSys.Models;

namespace FoodOderingSys.Controllers
{
    public class LoginController : Controller
    {
        FoodOrderingProjectEntities4 db = new FoodOrderingProjectEntities4();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(OwnerLoginTbl s )
        {
            if (ModelState.IsValid == true) 
            {
                var Credential = db.OwnerLoginTbls.Where(model => model.Ownername == s.Ownername && model.OwnerPassword == s.OwnerPassword).FirstOrDefault();
                if (Credential == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }
                else 
                {
                    Session["Ownername"] = s.Ownername;
                    return RedirectToAction("Index", "EmployeeTbls");
                }
            }
            return View();
        }
    }
}