﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TDC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        
        public DateTime checkIn { get; set; }

        // 1 = easy 2 = intermediate  3 = advanced
        public int level { get; set; }

        // 1 = Young Professional 2 = High School Student 3 = College Student
        public int type { get; set; }

        // 1 = Male 2 = Female 3  = Other
        public int? sex { get; set;}

        //True = participated last year, False = did not
        [Display(Name = "Did you participate last year?")]
        public bool again { get; set; }

        //True = Participant, False = Organizer
        
        public bool ParticipantOrOrgan { get; set; }
        //Zipcode
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zipcode")]
        public int Zip { get; set; }

        //Organization user is affiliated with
        [Display(Name = "Enter group affiliation")]
        public string Affil { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }

        public virtual ICollection<Income> Income { get; set; }

        public virtual ICollection<Reflection> Reflection { get; set; }

        public virtual ICollection<ShockUser> ShockUser { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TDC.Models.Reflection> Reflections { get; set; }

        public System.Data.Entity.DbSet<TDC.Models.Income> Incomes { get; set; }

        public System.Data.Entity.DbSet<TDC.Models.Expense> Expenses { get; set; }
       
    }
}