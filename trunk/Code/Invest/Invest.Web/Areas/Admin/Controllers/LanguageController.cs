using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        //
        // GET: /Admin/Language/
        public ActionResult Index()
        {
            var invest = new InvestContext();
            return View(invest.Language.ToList());
        }
	}
}