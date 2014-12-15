using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDC.Models;

namespace TDC.Tools
{
    public class TeamStats
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        //returns team Money Totals. To be orderd later
        public List<StatsTuple> getTeamMoney() 
        {
            var list = new List<StatsTuple>();
            foreach (var x in db.Users)
            {
                if (!list.Exists(z => z.teamName.ToLower() == x.Affil.ToLower() ))
                {
                    list.Add(getIndTeamTotal(x));
                }
            }
            return list;
        }

        
        //Returns most popular items with amt spent total
        //dont be confused by team name. It can be product name
        public List<StatsTuple> getPopItem()
        {
            var tempTuple = new StatsTuple();
            var list = new List<StatsTuple>();
            foreach (var x in db.Expenses)
            {
                if (!list.Exists(z => z.teamName.ToLower() == x.product.ToLower()))
                {
                    tempTuple.teamName = x.product;
                   var tempList = db.Expenses.Where(z => z.product == x.product);
                   tempTuple.amt = tempList.Sum(k => k.cost);
                   list.Add(tempTuple);

                   
                }
            }
            return null;
        }

        //list of total number of people on each team
        public List<StatsTuple> getTotalTeam()
        {
            return null;
        }
        //get an individual team total
        public static StatsTuple getIndTeamTotal(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var team = new StatsTuple();
            //only converts all to lowercase
            string teamName = user.Affil.ToLower();
            var list = db.Users.Where(x => x.Affil.ToLower().Contains(teamName));
            team.teamName = user.Affil;
            team.amt = list.Sum(x => x.getBalance());
            return team;
            



        }


    }

    public class StatsTuple {
        public string teamName { get; set; }
        public decimal amt { get; set; }
    
    
    }
}