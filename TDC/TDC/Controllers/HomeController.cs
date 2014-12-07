using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDC.Models;

namespace TDC.Controllers
{
    public class HomeController : Controller
    {
        //This shows how to get currently signed in user.
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<User> UserManager { get; set; }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<User>(new UserStore<User>(this.ApplicationDbContext));
            ViewBag.Message = "Your application description page.";
            var user = UserManager.FindById(User.Identity.GetUserId());
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}