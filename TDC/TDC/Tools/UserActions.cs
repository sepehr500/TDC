using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDC.Models;

namespace TDC.Tools
{
    public class UserActions
    {
        //use this to get current user
        public static User getUser(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            return user;
        }


        //Returns number of people on individual team
        public static int teamCount(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //only converts all to lowercase
            string teamName = user.Affil.ToLower();
            var list = db.Users.Where(x => x.Affil.ToLower().Contains(teamName));
            return list.Count();



        }

        //Returns a List of IFundControl that can be used to get funds. Log.Sum(x => x.getAmt()) to get sum of log. 
        public static List<IFundControl> getLog(string id)
        {

            var Log = new List<IFundControl>();


            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);

            foreach (Income x in user.Income)
            {
                Log.Add(x);
            }
            foreach (Expense x in user.Expense)
            {
                Log.Add(x);
            }
            foreach (ShockUser x in user.ShockUser)
            {
                Log.Add(x);
            }
            return Log;



        }
        // Check if a day has passed and add income if it has. If null is returned that means that a day has not passed. 
        public static void addDayIncome(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);

            if (user.incomeCheck.Day < DateTime.Now.Day)
            {
                if (user.level == 1 || user.level == 2)
                {


                    user.incomeCheck = DateTime.Now;
                    user.Income.Add(new Income { Amount = 2, Date = DateTime.Now, UserId = user.Id });
                    user.Message.Add(new Message{notification =  "You received $2 in daily income.", UserId = user.Id});
                    db.SaveChanges();
                }
                //Do advanced income
                else
                {
                    user.incomeCheck = DateTime.Now;
                    decimal getIncome = getRandIncome();
                    user.Income.Add(new Income { Amount = getIncome, Date = DateTime.Now, UserId = user.Id });
                    db.SaveChanges();
                    if (getIncome == 0)
                    {
                        
                        user.Message.Add(new Message { notification = "Sorry. No income today.", UserId = user.Id });
                    }
                    else
                    {
                        string deets = "You received $" + getIncome + " in daily income.";
                        user.Message.Add(new Message { notification = deets , UserId = user.Id });
                    }
                    db.SaveChanges(); 

                }


            }


        }
        private static decimal getRandIncome()
        {
            Random x = new Random((int)DateTime.Now.Ticks);
            int num = x.Next(3);
            switch (num)
            {
                case 0:
                    return 0;
                case 1:
                    return 3;
                case 2:
                    return 2;
                case 3:
                    return 1;
                default:
                    return 100;
            }


        }

        public static string messageParser(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            string final = "";
            foreach (var item in user.Message)
            {
                final += item.notification + "/n";
                user.Message.Remove(item); 
            }
            db.SaveChanges();
            return final;
            


        }


    }

    //Interface to control Funds. To add up funds use Log.Sum(x => x.getAmt())
    public interface IFundControl
    {
        decimal getAmt();

        string getType();

        DateTime getDate();
    }







}