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
            
            var ApplicationDbContext = new ApplicationDbContext();
            var UserManager = new UserManager<User>(new UserStore<User>(ApplicationDbContext));
            var user = UserManager.FindById(id);
            return user;
        }

        //Returns the users balance
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




    }

    





}