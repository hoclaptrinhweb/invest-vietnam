using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Services;

namespace Invest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadMenu()
        {
            var csv = new CategoryServices();
            var result = csv.GetAllByParent(0,true,true);
            return PartialView(result);
        }
        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("lang", lang);//{ HttpOnly = true };
            Response.AppendCookie(langCookie);
            return RedirectToAction("Index", "Home", new { culture = lang.Substring(0,2) });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}