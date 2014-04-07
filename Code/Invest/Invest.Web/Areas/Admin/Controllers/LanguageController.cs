using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Services;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        //
        // GET: /Admin/Language/
        public ActionResult Index()
        {
            var langService = new LanguageServices();
            return View(langService.GetAll());
        }
	}
}