using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Invest.Services;

namespace Invest.Web.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        public ActionResult Index(string Name, int Id)
        {
            var csv = new CategoryServices();
            var nsv = new NewsServices();
            var data = nsv.GetNewsByID(Id);
            var result = data.ToModel();
            result.CategoryId = data.News_Category_Mapping.FirstOrDefault().CategoryId;

            var CurrCat = csv.GetCategoryByID(result.CategoryId);
            var TreeMenu = new List<CategoryModel>();
            GetCategoryByParent(CurrCat.ToModel(), TreeMenu);
            ViewBag.TreeMenu = TreeMenu;

            return View(result);
        }

        public static CategoryModel GetCategoryByParent(CategoryModel curr, List<CategoryModel> TreeMenu)
        {
            var invest = new InvestContext();
            var result = invest.Category.Where(c => c.Id == curr.ParentCategoryId).FirstOrDefault().ToModel();
            if (result == null)
            {
                TreeMenu.Insert(0, curr);
                return curr;
            }
            else
            {
                TreeMenu.Insert(0, curr);
                return GetCategoryByParent(result, TreeMenu);
            }

        }

    }
}