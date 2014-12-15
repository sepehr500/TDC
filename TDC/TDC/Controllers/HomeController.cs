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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,product,cost,UserID")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.cost = expense.cost * -1;
                expense.UserID = User.Identity.GetUserId();
                expense.Date = DateTime.Now;
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expense);
        }


    }
}