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
    public static class UserActions 
    {

        //use this to get current user
        public static User getUser(string id)
        {
            
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            return user;
        }

        //Returns the users balance
        //May be obsolete. Can simply sum the user Log
        public static decimal getBalance(string id) {
            decimal total = 0;
            
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            
            foreach (Income x in user.Income )
            {
                total += x.Amount;
            }
            foreach (Expense x in user.Expense)
            {
                total += x.cost;
            }
            foreach (ShockUser x in user.ShockUser)
            {
                total += x.ShockLU.Amount;
            }

            return total;
        
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