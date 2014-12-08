using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using TDC.Models;

namespace TDC.Tools
{


    public class ShockCalc
    {
        
        public static ShockLU doIndShock(string id)
        {
            
            ApplicationDbContext db = new ApplicationDbContext();  
            var user = UserActions.getUser(id);
            
            
            DateTime startDate = user.checkIn;
            Random rnd = new Random((int)startDate.Ticks);
            int randHours = rnd.Next(12,30);
            DateTime checkTime = startDate.AddHours(randHours);
            if (DateTime.Now.Ticks > checkTime.Ticks)
            {
                
                user.checkIn = DateTime.Now;
                ShockLU randShock = getRandIndShock(id);
                ShockUser newShock = new ShockUser { Date = DateTime.Now, ShockLUId = randShock.ID, UserId = id };
                db.ShockUser.Add(newShock);
                db.SaveChanges();

                return randShock;
            }

            return null;


        }

        public static void doGlobalShock(string id) 
        { 
        
        
        
        
        }

        protected static ShockLU getRandIndShock(string id) {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = UserActions.getUser(id);

            var randList = db.ShockLU.SqlQuery("SELECT TOP 1 column FROM table ORDER BY NEWID() ");
            return randList.First();
            
        }



    }
}