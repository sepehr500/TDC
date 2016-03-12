using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            return user;
        }

        //Sends Remitance
        public static void sendRemit(User sender , User recipiant , decimal amt)
        {
            using ( var ApplicationDbContext = new ApplicationDbContext())
            {
                ApplicationDbContext.Expenses.Add(new Expense()
                {
                    cost = amt * -1,
                    Date = DateTime.Now.AddHours(sender.TimeZoneOffset),
                    UserID = sender.Id,
                    product = "Remitance"
                });
                ApplicationDbContext.Incomes.Add(new Income()
                {
                    Amount = amt,
                    Date = DateTime.Now.AddHours(recipiant.TimeZoneOffset),
                    UserId = recipiant.Id
                });
                ApplicationDbContext.Message.Add(new Message()
                {
                    notification = "You recieved " + amt + " from " + sender.Email, UserId = recipiant.Id
                });
                ApplicationDbContext.SaveChanges();

            }
            
            
        }

        //Returns number of people on individual team
        public static int teamCount(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //only converts all to lowercase
            string teamName = user.Affil.ToLower();
            var list = db.Users.Where(x => x.Affil.ToLower().Equals(teamName));
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
            Log.Sort();
            return Log;



        }
        // Check if a day has passed and add income if it has. If null is returned that means that a day has not passed. 
        public static void addDayIncome(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var UserManager = new UserManager<User>(new UserStore<User>(db));
                var user = UserManager.FindById(id);

                if (user.incomeCheck.AddHours(user.TimeZoneOffset).Day < DateTime.Now.AddHours(user.TimeZoneOffset).Day || user.incomeCheck.AddHours(user.TimeZoneOffset).Month < DateTime.Now.AddHours(user.TimeZoneOffset).Month)
                {

                    if (user.level == 2)
                    {



                        User change = db.Users.Find(user.Id);
                        change.incomeCheck = DateTime.Now;
                        change.Income.Add(new Income { Amount = 2, Date = DateTime.Now.AddHours(user.TimeZoneOffset), UserId = user.Id , User = null });
                        change.Message.Add(new Message { notification = "You received $2 in daily income.", UserId = user.Id });
                        db.SaveChanges();

                    }
                    //Do advanced income
                    if (user.level == 3)
                    {
                        User change = db.Users.Find(user.Id);
                        change.incomeCheck = DateTime.Now;
                        decimal getIncome = getRandIncome();
                        change.Income.Add(new Income { Amount = getIncome, Date = DateTime.Now.AddHours(user.TimeZoneOffset), UserId = user.Id , User = null });
                        db.SaveChanges();
                        if (getIncome == 0)
                        {

                            change.Message.Add(new Message { notification = "Sorry. No income today.", UserId = user.Id });
                            db.SaveChanges();
                        }
                        else
                        {
                            string deets = "You received $" + getIncome + " in daily income.";
                            change.Message.Add(new Message { notification = deets, UserId = user.Id });
                            db.SaveChanges();
                        }

                    }


                }
                db.SaveChanges();
            }

        }
        private static decimal getRandIncome()
        {
            Random x = new Random((int)DateTime.Now.Ticks);
            int num = x.Next(11);
            if (num < 1)
            {
                return 0;
            }
            switch (num)
            {
                case 5:
                case 6:
                case 3:
                case 2:
                    return 1;
                case 7:
                case 8:
                case 9:
                case 4:
                    return 2;
                case 10:
                case 1:
                    return 3;
                default:
                    return 0;
            }
            


        }

        public static string messageParser(User user)
        {
            string final = "";
            if (user != null)
            {
                ApplicationDbContext db = new ApplicationDbContext();

                
                var list = user.Message.ToList();
                foreach (var item in user.Message)
                {
                    final += item.notification + "\n\n";

                    Message delete = db.Message.Find(item.ID);
                    db.Message.Remove(delete);
                    db.SaveChanges();

                }
            }
            return final;
            


        }


    }

    //Interface to control Funds. To add up funds use Log.Sum(x => x.getAmt())
    public interface IFundControl : IComparable<IFundControl>
    {
        decimal getAmt();

        string getType();

        DateTime getDate();
    }







}