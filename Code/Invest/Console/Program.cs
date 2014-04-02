using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Migrations;
using DomainClasses;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
        }

        static void TestAsync()
        {
            var task = Task.Factory.StartNew<int>(SlowOperation);
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Slow operation result: {0}", task.Result);
            Console.WriteLine("Main complete on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static int SlowOperation()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }

        public static void CreateDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InvestContext,Configuration>());
            var invest = new InvestContext();
            invest.Database.Initialize(true);
        }
    }
}
