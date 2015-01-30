using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
               // var shock = ShockCalc.doIndShock(user.Id);
                ShockCalc.eventChecker(user);
                ViewBag.message = UserActions.messageParser(user);
                
                

                


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
            ViewBag.teamMoney =  TeamStats.getTeamMoney().OrderByDescending(x => x.amt);
            ViewBag.teamTotal = TeamStats.getPopItem().OrderByDescending(x => x.amt);
            ViewBag.numOnTeams = TeamStats.getTotalTeam().OrderByDescending(x => x.amt);
            return View();
        }

        public ActionResult ReflectionView() {
            var user = UserActions.getUser(User.Identity.GetUserId());

            return View(user.Reflection.ToList());
        }
        public ActionResult CreateReflection()
        {
            
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReflection([Bind(Include = "ID, Memo")]  Reflection reflection)
        {
                var user = UserActions.getUser(User.Identity.GetUserId());
                reflection.UserId = user.Id;
                reflection.Date = DateTime.Now;
                db.Reflections.Add(reflection);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

        }



    }
}