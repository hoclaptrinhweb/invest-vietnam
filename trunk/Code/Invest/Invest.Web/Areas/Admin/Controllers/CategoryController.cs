using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Services;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Admin/Category/
        public ActionResult Index()
        {
            var CategoryServices = new CategoryServices();
            var result = CategoryServices.GetAllByParent(0);
            return View(result);
        }
	}
}