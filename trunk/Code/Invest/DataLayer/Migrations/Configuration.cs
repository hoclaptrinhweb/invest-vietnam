namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DomainClasses;

    public class Configuration : DbMigrationsConfiguration<DataLayer.InvestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataLayer.InvestContext context)
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
            try
            {
                var invest = new InvestContext();
                invest.Category.AddOrUpdate(
                    p => p.Name,
                    new Category { Name = "Why VietNam" ,DisplayOrder = 0},
                    new Category { Name = "Industries"  ,DisplayOrder = 1},
                    new Category { Name = "Where to invest"  ,DisplayOrder = 2},
                    new Category { Name = "Doing Business"  ,DisplayOrder = 3},
                    new Category { Name = "Life in Korea"  ,DisplayOrder = 4},
                    new Category { Name = "Resources"  ,DisplayOrder = 5},
                    new Category { Name = "About Us", DisplayOrder = 6 },
                    new Category { Name = "Investment Consulting", DisplayOrder = 7 }
                    );
                invest.SaveChanges();
            }
            catch
            {
                var n = 0;
            }

        }
    }
}
