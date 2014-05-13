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
            ViewBag.CurrTitle = CurrCat.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
            
            var Parent = CheckParent(CurrCat, allCat);
            ViewBag.MenuTitle = Parent.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);

            var result = csv.GetAllByParent(Parent.Id, true, true);
            var data = result.Select(x =>
            {
                var a = x.ToModel();
                a.Name = x.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
                return a;
            }).ToList();

            ViewBag.TreeMenu = GetCategoryByParent(CurrCat, new List<Category>()); ;
            
            return View(data);
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
            model.NewsCategoryViewModel = newsServices.GetNewsByCategory(Id, EngineContext.WorkingLanguage.Id).Select(n =>
                     new NewsCategoryViewModel()
                     {
                         Id = n.Id,
                         Title = n.Title,
                         Brief = n.Short,
                         ImagePath = invest.Picture.Where(p => invest.News_Picture_Mapping.Any(m => m.PictureId == p.Id && m.NewsId == n.Id)).Select(p => p.PathUrl).FirstOrDefault()
                     }
                    ).ToList();
            return PartialView(model);
        }

        public ActionResult PartialLeftMenu(int Id)
        {
            var csv = new CategoryServices();
            var invest = new InvestContext();
            ViewBag.Id = Id;
            var allCat = csv.GetAll();

            var CurrCat = allCat.Where(c => c.Id == Id).FirstOrDefault();
            ViewBag.CurrTitle = CurrCat.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);

            var Parent = CheckParent(CurrCat, allCat);
            ViewBag.MenuTitle = Parent.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);


            var result = csv.GetAllByParent(Parent.Id, true, true);
            var data = result.Select(x =>
            {
                var a = x.ToModel();
                a.Name = x.GetLocalized(n => n.Name, EngineContext.WorkingLanguage.Id, false, false);
                return a;
            }).ToList();
            return PartialView(data);
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