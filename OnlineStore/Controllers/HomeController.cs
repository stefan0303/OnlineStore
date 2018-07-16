using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = "User,Admin")]//Only User and Admins can see this Action Views

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        [Authorize(Roles = "Admin")] //Only admin can see About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}