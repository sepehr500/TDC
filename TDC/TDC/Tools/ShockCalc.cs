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
        
        //If null is returned then there is no shock, else a ShockLU object will be returned and that holds shock name and value
        public static ShockLU doIndShock(string id)
        {
            //get user id
            ApplicationDbContext db = new ApplicationDbContext();  
            var user = UserActions.getUser(id);
            
            
            DateTime startDate = user.checkIn;
            //seed will always be consistent
            Random rnd = new Random((int)startDate.Ticks);
            int randHours = rnd.Next(12,30);
            DateTime checkTime = startDate.AddHours(randHours);
            if (DateTime.Now.Ticks > checkTime.Ticks)
            {
                
                user.checkIn = DateTime.Now;
                ShockLU randShock = getRandShock();
                ShockUser newShock = new ShockUser { Date = DateTime.Now, ShockLUId = randShock.ID, UserId = id };
                db.ShockUser.Add(newShock);
                db.SaveChanges();

                return randShock;
            }

            return null;


        }
        //Does a community shock, then returns the shock and the name of the team in a tuple so it can be shown in the view. 
        public static Tuple<ShockLU, string> doCommunityShock() {
            ApplicationDbContext db = new ApplicationDbContext();  
            string team = getRandTeam();
            ShockLU randShock = getRandShock();
            foreach (var item in db.Users)
            {
                if (item.Affil.ToLower() == team.ToLower())
                {
                    db.ShockUser.Add(new ShockUser { Date = DateTime.Now, ShockLUId = randShock.ID, UserId = item.Id }); 

                }
            }

            return Tuple.Create(randShock , team); 
        
        }

        //Dont think I will implement this. There are only 2 or 3 global shocks, so might make sense to write manually. 
        public static void doGlobalShock(string id) 
        { 
        
        
        
        
        }

        protected static ShockLU getRandShock() {
            ApplicationDbContext db = new ApplicationDbContext();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int randNum = rnd.Next(db.ShockLU.Count());
            var randShock = db.ShockLU.ElementAt(randNum);
            return randShock;
            
        }
        public static string getRandTeam() {
            ApplicationDbContext db = new ApplicationDbContext();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int randNum = rnd.Next(db.Users.Count());
            var randList = db.Users.ElementAt(randNum);
            return randList.Affil;

        
        
        }



    }
}