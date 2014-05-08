namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Invest.Core;

    public class Configuration : DbMigrationsConfiguration<DataLayer.InvestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // if model changes involve data lose
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DataLayer.InvestContext context)
        {
            //  This method will be called after migrating to the latest version.
            try
            {
                var invest = new InvestContext();
              //  invest.Database.ExecuteSqlCommand(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\script.sql"));
            }
            catch
            {
                var n = 0;
            }

        }
    }
}
