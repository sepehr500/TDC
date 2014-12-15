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

        private ApplicationDbContext db = new ApplicationDbContext();
        

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var user = UserActions.getUser(User.Identity.GetUserId());

                return View(user);
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

        public ActionResult Stats()
        {
            ViewBag.teamMoney = TeamStats.getTeamMoney();
            ViewBag.teamTotal = TeamStats.getPopItem();
            ViewBag.numOnTeams = TeamStats.getTotalTeam();
            return View();
        }



    }
}