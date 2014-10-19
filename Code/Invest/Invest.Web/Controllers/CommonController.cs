using DataLayer;
using Invest.Services;
using Invest.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invest.Web.Controllers
{
    public class CommonController : BaseController
    {

        public ActionResult Search(string key, int orderType)
        {
            var invest = new InvestContext();
            var newsServices = new NewsServices();
            var model = invest.News.Where(n => n.Title.Contains(key) && n.LanguageId == EngineContext.WorkingLanguage.Id && n.Published == true).OrderByDescending(n => n.CreatedDate).Select(n =>
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