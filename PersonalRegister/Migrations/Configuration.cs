namespace PersonalRegister.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PersonalRegister.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalRegister.DataAccessLayer.RegisterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalRegister.DataAccessLayer.RegisterContext context)
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

            context.Personals.AddOrUpdate(
                p => p.Department,  // want to search via Department as my identifier
                new Personal { FirstName = "Ayesha", LastName = "Azam", Department = "Development", Position = "Manager", Salary = 40000  },
                new Personal { FirstName = "bob", LastName = "ericsson", Department = "Sales", Position = "Manager", Salary = 35000 }, 
                new Personal { FirstName = "sofia", LastName = "ericsson", Department = "IT", Position = "assistance", Salary = 41000 }
                );
            
        }
    }
}
