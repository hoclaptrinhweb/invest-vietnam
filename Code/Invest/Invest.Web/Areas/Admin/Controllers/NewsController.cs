using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Invest.Core;
using Invest.Services;
using PagedList;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        //
        // GET: /Admin/News/
        public ActionResult Index(string currentFilter, string qr, int? key, int? page)
        {
            int temSize = 0;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (qr != null)
                qr = qr.ToLower();
            else
                qr = currentFilter == null ? "" : currentFilter.ToLower();
            ViewBag.CurrentFilter = qr;
            ViewBag.SearchKey = key;
            ViewBag.CurrentQ = qr;


            var _languageService = new LanguageServices();
            ViewBag.AllLanguages = _languageService.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            var invest = new InvestContext();
            var result = invest.News.Select(n => new NewsModel()
            {
                Id = n.Id,
                LanguageId = n.LanguageId,
                Title = n.Title,
                LanguageName = n.Language.Name,
                Published = n.Published,
                CommentCount = n.CommentCount,
                CreatedDate = n.CreatedDate
            }).OrderBy(n => n.CreatedDate);
            return View(result.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int id = 0)
        {
            var invest = new InvestContext();
            var result = invest.News.Where(n => n.Id == id).FirstOrDefault();
            if (id == 0)
                result = new News();
            var model = result.ToModel();
            var allLang = invest.Language.ToList().Select(l => new SelectListItem()
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            model.AvailableLanguages = allLang;
            model.News_Picture = invest.News_Picture_Mapping.Where(n => n.NewsId == id).Select(n => new News_Picture_MappingModel()
                {
                    UrlPath = n.Picture.PathUrl,
                    DisplayOrder = n.DisplayOrder,
                    Id = n.Id
                }).OrderBy(n => n.DisplayOrder).ToList();
            return View(model);
        }

        public ActionResult AllPicture(int NewsID)
        {
            var invest = new InvestContext();
            var model = invest.News_Picture_Mapping.Where(n => n.NewsId == NewsID).Select(n => new News_Picture_MappingModel()
            {
                UrlPath = n.Picture.PathUrl,
                DisplayOrder = n.DisplayOrder,
                Id = n.Id
            }).OrderBy(n => n.DisplayOrder).ToList();
            return PartialView("_PartialAllPicture", model);
        }


        public ActionResult DeletePicture(List<int> ids = null)
        {
            var invest = new InvestContext();
            var id = ids.First();
            var dbEnty = invest.News_Picture_Mapping.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Ngôn ngữ này hiện tại không tồn tại trong hệ thống");
            else
            {
                invest.News_Picture_Mapping.Remove(dbEnty);
                invest.SaveChanges();
            }
            return jsonResult();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var News = model.ToEntity();
                    var NewsService = new NewsServices();
                    NewsService.Add(News);
                    return base.jsonResult();
                }
                throw new Exception("lỗi");
            }
            catch (Exception ex)
            {
                return base.jsonResult(false, ex.Message);
            }
        }

        public ActionResult AddPicture(int NewsID, string UrlPath, int DisplayOrder)
        {
            var newsServices = new NewsServices();
            newsServices.Add(NewsID, UrlPath, DisplayOrder);
            return base.jsonResult();
        }

    }
}