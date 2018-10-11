using OrganizerMVC.Models;

namespace OrganizerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrganizerMVC.Models.OrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.OrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Sports.Any())
            {
                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Baby Foot"
                    }
                );

                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ping Pong"
                    }
                );

                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cricket"
                    }
                );

                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Hockey"
                    }
                );

                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "E-Sport"
                    }
                );

                context.Sports.Add(new Sport()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Surf"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
