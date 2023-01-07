using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOderingSys.Models;

namespace FoodOderingSys.Controllers.Customer
{
    public class OrderDetailsPController : Controller
    {
        // GET: OrderDetailsP
        public ActionResult Index()
        {
            FoodOrderingProjectEntitiesCat sd = new FoodOrderingProjectEntitiesCat();
            List<CustomerTbl> CustomerID = sd.CustomerTbls.ToList();
            List<CustomerTbl> CustomerName = sd.CustomerTbls.ToList();


            return View();
        }
    }
}