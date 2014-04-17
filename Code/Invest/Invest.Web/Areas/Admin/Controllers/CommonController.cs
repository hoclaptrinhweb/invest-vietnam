using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Core.Infrastructure;
using Invest.Services;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Admin/Common/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LanguageSelected(int customerlanguage)
        {
            var _languageService = new LanguageServices();
            var language = _languageService.GetLanguageByID(customerlanguage);
            if (language != null)
            {
                var langCookie = new HttpCookie("lang", language.LanguageCulture);//{ HttpOnly = true };
                Response.AppendCookie(langCookie);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}