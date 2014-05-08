using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Services;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class LanguageController : BaseController
    {
        //
        // GET: /Admin/Language/
        public ActionResult Index()
        {
            var langService = new LanguageServices();
            return View(langService.GetAll());
        }

        public ActionResult Edit(int id = 0)
        {
            var langService = new LanguageServices();
            var lang = langService.GetLanguageByID(id);
            return View(lang);
        }

        [HttpPost]
        public ActionResult Edit(Language language)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var langService = new LanguageServices();
                    langService.Add(language);
                    return base.jsonResult();
                }
                throw new Exception("lỗi");
            }
            catch (Exception ex)
            {
                return base.jsonResult(false, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(List<int> ids = null)
        {
            try
            {
                if (ids == null)
                    throw new Exception("Bạn chưa chọn Ngôn ngữ!");
                var langService = new LanguageServices();
                langService.Delete(ids.First());
                return jsonResult();
            }
            catch (Exception ex)
            {
                return jsonResult(false, ex.Message);
            }
        }

        public ActionResult Resources(int languageId = 0)
        {
            var _languageService = new LanguageServices();
            var language = _languageService.GetLanguageByID(languageId);
            ViewBag.AllLanguages = _languageService.GetAll().Select(x => new SelectListItem
                {
                    Selected = (x.Id.Equals(languageId)),
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList(); ;
            var _localRe = new LocaleStringResourceServices();
            var model = _localRe.GetAll(languageId).Select(x => new LanguageResourceModel()
                    {
                        LanguageId = languageId,
                        LanguageName = language.Name,
                        Id = x.Id,
                        Name = x.ResourceName,
                        Value = x.ResourceValue
                    });
            return View(model);
        }
    }
}