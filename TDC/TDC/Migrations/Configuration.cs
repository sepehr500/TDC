namespace TDC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TDC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TDC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TDC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.GlobalDate.Add(new GlobalDate { Date = DateTime.Now, Type = 1 });
            context.GlobalDate.Add(new GlobalDate { Date = DateTime.Now, Type = 2 });
            //Individual Shocks
            context.ShockLU.Add(new ShockLU { Amount =  (decimal)-.25, Description = "It’s the start of a new school year. You paid .25 cents for your child’s books.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount =  (decimal)-.35, Description = "There has been a death in your community.  You paid .35 cents towards burial expenses.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal).25, Description = "You found .25 cents. Lucky you!", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.55, Description = "You have fallen ill. You paid .50 cents to visit the doctor.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.15, Description = "Your daughter has graduated from high school. You paid .15 cents to throw her a party.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.10, Description = "You come upon a roadblock. You paid .10 cent “tax” to local officials.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.10, Description = "You miss a loan payment to your local money lender. You paid .10 cents in late fees.", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal).10, Description = "Your spouse successfully migrates. Enjoy .10 cents in remittances!", ShockType = 1 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.10, Description = "Your community hosts its annual spring festival. You paid .10 cents to participate.", ShockType = 1 });
            //Community Shocks
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.15, Description = "was affected by  high Corn prices skyrocket. Each member lost .15 cents.", ShockType = 2 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.10, Description = "bus drivers go on strike. Each member paid .10 cents to take a taxi to work.", ShockType = 2 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal).20, Description = "Mayoral candidates campaign. Each person receives .20 cents extra.", ShockType = 2 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.20, Description = "experiences Hurricane Zelda. Each member pays .20 cents for clean up.", ShockType = 2 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal)-.05, Description = "local power grid fails. Each member pays .05 cents.", ShockType = 2 });
            context.ShockLU.Add(new ShockLU { Amount = (decimal).05, Description = "forms a savings group. Each person receives .05 cents extra.", ShockType = 2 });
            context.SaveChanges();

        }
    }
}
