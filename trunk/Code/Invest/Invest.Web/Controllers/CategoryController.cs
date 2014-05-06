using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Services;

namespace Invest.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(string Name, int Id)
        {
            var csv = new CategoryServices();
            var allCat = csv.GetAll();
            var CurrCat = allCat.Where(c => c.Id == Id).FirstOrDefault();
            var Parent = CheckParent(CurrCat, allCat);
            var result = csv.GetAllByParent(Parent.Id, true, true);
            return View(result);
        }

        public static Category CheckParent(Category Parent, IEnumerable<Category> allCat)
        {
            var result = allCat.Where(c => c.Id == Parent.ParentCategoryId).FirstOrDefault();
            if (result == null)
                return Parent;
            else
                return CheckParent(result, allCat);
        }
    }
}