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
using System.Data.Entity;

namespace TDC.Tools
{


    public class ShockCalc
    {
        public static void eventChecker(User user){
            if (user != null)
            {
                doIndShock(user.Id);
                doGlobalShock();
                doCommunityShock();
                UserActions.addDayIncome(user.Id);
            }
            
            
        
        
        }

        
        //If null is returned then there is no shock, else a ShockLU object will be returned and that holds shock name and value
        private static void doIndShock(string id)
        {
            //get user id
            ApplicationDbContext db = new ApplicationDbContext();  
            var user = UserActions.getUser(id);
            var another = UserActions.getUser(id);
            
            
            DateTime startDate = user.checkIn;
            //seed will always be consistent
            Random rnd = new Random((int)startDate.Ticks);
            int randHours = rnd.Next(12,30);
            DateTime checkTime = startDate.AddHours(randHours);
            if (DateTime.Now.Ticks > checkTime.Ticks)
            {
                User change = db.Users.Find(user.Id);
                change.checkIn = DateTime.Now;
                
                
                ShockLU randShock = getRandShock(1);
                ShockUser newShock = new ShockUser { Date = DateTime.Now.AddHours(user.TimeZoneOffset), ShockLUId = randShock.ID, UserId = id };
                db.ShockUser.Add(newShock);
                db.Message.Add(new Message { notification = getIndString(randShock), UserId = user.Id });
                
                db.SaveChanges();

            }



        }
        //Does a community shock to the richest team, then returns the shock and the name of the team in a tuple so it can be shown in the view. 
        private static void doCommunityShock() {
            
            ApplicationDbContext db = new ApplicationDbContext();
            if (db.GlobalDate.Find(2).Date.AddHours(42) < DateTime.Now)
            {
                var teamList = TeamStats.getTeamMoney().OrderByDescending(x => x.amt);
                string team = teamList.First().teamName;
                ShockLU randShock = getRandShock(2);
                
                foreach (var item in db.Users)
                {
                    if (item.level != 1)
                    {


                        if (item.Affil.ToLower() == team.ToLower())
                        {

                            db.ShockUser.Add(new ShockUser { Date = DateTime.Now.AddHours(item.TimeZoneOffset), ShockLUId = randShock.ID, UserId = item.Id });

                        }

                        db.Message.Add(new Message { notification = getCommunityString(item.Affil, randShock), UserId = item.Id });
                    }
                }

                db.GlobalDate.Find(2).Date = DateTime.Now;

                db.SaveChanges();
            }
        
        }

        //Dont think I will implement this. There are only 2 or 3 global shocks, so might make sense to write manually. 
        private static void doGlobalShock() 
        {
            ApplicationDbContext db = new ApplicationDbContext();  
            if (db.GlobalDate.First().Date.AddHours(50) < DateTime.Now)
            {
                ShockLU randShock = getRandShock(3); 
                foreach (var item in db.Users)
                {
                    if (item.level != 1)
                    {

                        db.ShockUser.Add(new ShockUser { Date = DateTime.Now.AddHours(item.TimeZoneOffset), ShockLUId = randShock.ID, UserId = item.Id });
                        db.Message.Add(new Message { notification = getGlobalString(randShock), UserId = item.Id });

                    }
                    
                }

                db.GlobalDate.First().Date = DateTime.Now;
                db.SaveChanges();

            }

        
        
        
        
        }

        protected static ShockLU getRandShock(int type) {
            ApplicationDbContext db = new ApplicationDbContext();
            var randShock = (from row in db.ShockLU
                             where row.ShockType == type 
                        orderby Guid.NewGuid()
                        select row).FirstOrDefault();
            return randShock;
            
        }
        public static string getRandTeam() {
            ApplicationDbContext db = new ApplicationDbContext();
            var randTeam = (from row in db.Users
                             orderby Guid.NewGuid()
                             select row).FirstOrDefault(); 
            return randTeam.Affil;

        
        
        }

        private static string getCommunityString(string TeamName, ShockLU deets)
        {
            return "COMMUNITY SHOCK: " + TeamName + " " +  deets.Description;

        }
        private static string getIndString( ShockLU deets)
        {
            return "PERSONAL SHOCK: " + deets.Description;

        }
        private static string getGlobalString(ShockLU deets)
        {
            return "GLOBAL SHOCK: Everybody was " + deets.Description;

        }



    }
}