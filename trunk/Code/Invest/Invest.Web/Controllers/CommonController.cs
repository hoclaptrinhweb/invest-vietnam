using DataLayer;
using Invest.Services;
using Invest.Web.Framework;
using Invest.Web.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invest.Web.Controllers
{
    public class CommonController : BaseController
    {

        public ActionResult Search(SearchOptionModel searchOption)
        {
            var invest = new InvestContext();
            ViewBag.searchOption = searchOption;
            var newsServices = new NewsServices();
            var model = new List<NewsCategoryViewModel>();
            if (searchOption.OrderType == 1)
                model = invest.News.Where(n => n.Title.Contains(searchOption.Key) && n.LanguageId == EngineContext.WorkingLanguage.Id && n.Published == true).OrderByDescending(n => n.CreatedDate).Select(n =>
                       new NewsCategoryViewModel()
                       {
                           Id = n.Id,
                           Title = n.Title,
                           Brief = n.Short,
                           ImagePath = invest.Picture.Where(p => invest.News_Picture_Mapping.Any(m => m.PictureId == p.Id && m.NewsId == n.Id)).Select(p => p.PathUrl).FirstOrDefault()
                       }
                      ).ToList();
            if (searchOption.OrderType == 2)
                model = invest.News.Where(n => n.Title.Contains(searchOption.Key) && n.LanguageId == EngineContext.WorkingLanguage.Id && n.Published == true).OrderBy(n => n.CreatedDate).Select(n =>
                      new NewsCategoryViewModel()
                      {
                          Id = n.Id,
                          Title = n.Title,
                          Brief = n.Short,
                          ImagePath = invest.Picture.Where(p => invest.News_Picture_Mapping.Any(m => m.PictureId == p.Id && m.NewsId == n.Id)).Select(p => p.PathUrl).FirstOrDefault()
                      }
                     ).ToList();
            return View(model);
        }
    }
}