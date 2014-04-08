using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult jsonResult(bool success = true, string message = "", bool allowGet = true)
        {
            if (allowGet)
                return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
            return Json(new { success = success, message = message, JsonRequestBehavior.DenyGet });
        }
    }
}