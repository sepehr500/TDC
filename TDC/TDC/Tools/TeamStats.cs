﻿using System;
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
        public static List<StatsTuple> getTeamMoney() 
        {
            ApplicationDbContext db = new ApplicationDbContext();
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
        //Dont be confused by team name. It can be product name
        //HAVING TROUBLE WITH CASE SENSITIVITY
        public static List<StatsTuple> getPopItem()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var tempTuple = new StatsTuple();
            var tempTuple2 = new StatsTuple();
            
            var list = new List<StatsTuple>();
            var copy = db.Expenses.ToList();
            decimal sum = 0;
            foreach (var x in db.Expenses)
            {
                tempTuple.teamName = x.product;
                tempTuple.amt = x.cost;
                if (list.Contains(tempTuple) == false)
                {
                  //   tempTuple.teamName = x.product;
                  // var tempList = db.Expenses.Where(z => z.product.ToLower() == x.product.ToLower()).Select(z => z.cost).ToList();
                  //  var query = from z in db.Expenses where z.product.ToLower() == x.product.ToLower() select z;
                    
                    foreach (var item in copy)
                    {
                        tempTuple2.teamName = item.product;
                        tempTuple2.amt = item.cost;

                        if (tempTuple.Equals(tempTuple2))
                        {
                            sum += item.cost;
                        }
                        
                    }
                    //tempTuple.amt = tempList.Sum(k => k.cost);
                    list.Add(new StatsTuple() {amt = sum * -1 , teamName = x.product });

                    sum = 0;
                }
            }
            return list;
        }

        //list of total number of people on each team
        public static List<StatsTuple> getTotalTeam()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var list = new List<StatsTuple>();
            foreach (var x in db.Users)
            {
                if (!list.Exists(z => z.teamName.ToLower() == x.Affil.ToLower()))
                {
                    list.Add(new StatsTuple { amt = UserActions.teamCount(x), teamName = x.Affil });
                }
            }
            return list;

        }
        //get an individual team total
        public static StatsTuple getIndTeamTotal(User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var team = new StatsTuple();
            //only converts all to lowercase
            string teamName = user.Affil.ToLower();
            var list = db.Users.Where(x => x.Affil.ToLower() == teamName);
            team.teamName = user.Affil;
            foreach (var item in list)
            {
                team.amt += item.getBalance();
            }
            return team;
            



        }


    }

    public class StatsTuple : IEquatable<StatsTuple> , IComparable<StatsTuple> {
        public string teamName { get; set; }
        public decimal amt { get; set; }



        public bool Equals(StatsTuple other)
        {
            if (other.teamName != null)
            {
                if (other.teamName.ToLower().Remove(other.teamName.Length - 1).Equals(this.teamName) == true || other.teamName.ToLower().Contains(this.teamName.ToLower()) == true ||
                other.teamName.ToLower() + "s" == this.teamName.ToLower()
                )
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public int CompareTo(StatsTuple obj)
        {
            return Decimal.Compare(this.amt, obj.amt);
        }
    }
}