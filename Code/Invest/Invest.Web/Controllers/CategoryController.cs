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
    public class CategoryController : Controller
    {
        public ActionResult Index(string Name, int Id)
        {
            var csv = new CategoryServices();
            var invest = new InvestContext();
            ViewBag.Id = Id;
            var allCat = csv.GetAll();
            var CurrCat = allCat.Where(c => c.Id == Id).FirstOrDefault();
            var Parent = CheckParent(CurrCat, allCat);
            var result = csv.GetAllByParent(Parent.Id, true, true);
            var data = result.Select(x =>
            {
                var a = x.ToModel();
                a.Name = x.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
                return a;
            }).ToList();
            return View(data);
        }


        public ActionResult ContentCategory(int Id)
        {
            var csv = new CategoryServices();
            var invest = new InvestContext();
            var model = new CategoryContentModel();

            var result = csv.GetAllByParent(Id, true, true);
            model.Category = result.Select(x =>
            {
                var a = x.ToModel();
                var first = invest.Category_Picture_Mapping.Where(n => n.CategoryId == x.Id).Select(n => new Category_Picture_MappingModel()
                {
                    UrlPath = n.Picture.PathUrl,
                    DisplayOrder = n.DisplayOrder,
                    Id = n.Id
                }).OrderBy(n => n.DisplayOrder).FirstOrDefault();
                if (first != null)
                {
                    a.Category_Picture = new List<Category_Picture_MappingModel>();
                    a.Category_Picture.Add(first);
                }
                a.Name = x.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
                return a;
            }).ToList();

            var newsServices = new NewsServices();
            model.CategoryProductModel = csv.GetProductCategoriesByCategoryId(Id).Select(n =>
                     new CategoryProductModel()
                     {
                         Id = n.Id,
                         CategoryId = n.CategoryId,
                         NewsId = n.NewsId,
                         NewsName = newsServices.GetNewsByID(n.NewsId).Title,
                         DisplayOrder1 = n.DisplayOrder
                     }
                    ).ToList();
            return PartialView(model);
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