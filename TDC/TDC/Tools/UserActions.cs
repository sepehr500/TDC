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
       public static List<IFundControl> getLog(string id){
    
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




    }

    //Interface to control Funds. To add up funds use Log.Sum(x => x.getAmt())
    public interface IFundControl
    {
        decimal getAmt();

        string getType();

        DateTime getDate();
    }

    





}