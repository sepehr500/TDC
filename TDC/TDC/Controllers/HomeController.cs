using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDC.Models;
using TDC.Tools;

namespace TDC.Controllers
{
    public class HomeController : Controller
    {
        //This shows how to get currently signed in user.
        

        

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return View();
            }
            else return RedirectToAction("Splash", "Home");
            
          
        }

        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";
            //use this to get current user
            var userTest = UserActions.getUser(User.Identity.GetUserId());
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Splash()
        {
            return View();
        }
    }
}