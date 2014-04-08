using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Web.Areas.Admin.Models;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Admin/Index/
        public ActionResult Index()
        {
            var test = new TestLanguage();
            return View(test);
        }
	}
}