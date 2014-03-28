using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Migrations;
using DomainClasses;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();

        }

        public static void CreateDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InvestContext,Configuration>());
            var invest = new InvestContext();
            invest.Database.Initialize(true);
        }
    }
}
