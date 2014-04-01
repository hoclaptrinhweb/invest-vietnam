using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var t1 = DateTime.Now;
            var task1 = Task.Factory.StartNew<int>(() => Delay(2000));
            var task2 = Task.Factory.StartNew<int>(() => Delay(3000));
            var n = task1.Result;
            n = task2.Result;
            var total = DateTime.Now.Subtract(t1).TotalMilliseconds;
            return View(total);
        }

        public int Delay(int total)
        {
            Thread.Sleep(total);
            return 5;
        }

    }
}
