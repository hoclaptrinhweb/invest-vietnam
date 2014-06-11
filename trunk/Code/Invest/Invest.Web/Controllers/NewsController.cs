using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Invest.Core;
using Invest.Services;
using Invest.Web.Framework;

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
            ViewBag.TreeMenu = GetCategoryByParent(CurrCat, new List<Category>()); ;
            //Check Seo
            ViewBag.Title = result.MetaTitle;
            ViewBag.Description = result.MetaDescription;
            ViewBag.Keyword = result.MetaKeywords;
            return View(result);
        }

        public static List<Category> GetCategoryByParent(Category curr, List<Category> TreeMenu)
        {
            var invest = new InvestContext();
            var result = invest.Category.Where(c => c.Id == curr.ParentCategoryId).FirstOrDefault();
            curr.Name = curr.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
            if (result == null)
            {
                TreeMenu.Insert(0, curr);
                return TreeMenu;
            }
            else
            {
                TreeMenu.Insert(0, curr);
                return GetCategoryByParent(result, TreeMenu);
            }
        }

    }
}