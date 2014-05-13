using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleTest.Catalog;
using DataLayer;
using DataLayer.Migrations;
using Invest.Core;
using Invest.Services;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var invest = new InvestContext();
            //var cat = invest.Category.FirstOrDefault();
            //var test = Mapper.DynamicMap<Category, CategoryModel>(cat);
            CreateDatabase();
            Test();
        }

        static void Test()
        {
            var t = new NewsServices();
            var result = t.GetNewsByCategory(1,1).ToList();
        }

        static void TestAction()
        {
            Action<int>      example1 =  (int x) => Console.WriteLine("Write {0}", x);
            Action<int, int> example2 =  (x, y) => {
                                                        Console.WriteLine("Write {0} and {1}", x, y);
                                                        Console.WriteLine("test");
                                                    };
            Action           example3 =  () => Console.WriteLine("Done");
            // Call the anonymous methods.
            example1.Invoke(1);
            example2.Invoke(2, 3);
            example3.Invoke();
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InvestContext, Configuration>());
            var invest = new InvestContext();
            invest.Database.Initialize(true);
        }
    }
}
