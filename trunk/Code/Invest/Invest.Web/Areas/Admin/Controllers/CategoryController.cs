using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Services;
using Invest.Web.Areas.Admin.Models.Catalog;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        //
        // GET: /Admin/Category/
        public ActionResult Index()
        {
            var CategoryServices = new CategoryServices();
            var result = CategoryServices.GetAll();
            var data = result.Select(c =>
             {
                 var categoryModel = c;
                 categoryModel.Name = c.GetFormattedBreadCrumb(CategoryServices);
                 return categoryModel;
             });
            return View(data);
        }

        public ActionResult Edit(int id = 0)
        {
            var catService = new CategoryServices();
            var category = catService.GetCategoryByID(id);
            var _languageService = new LanguageServices();
            var model = category.ToModel();
            AddLocales(_languageService, model.Locales, (locale, languageId) =>
            {
                locale.Name = category.GetLocalized(x => x.Name, languageId, false, false);
                locale.Description = category.GetLocalized(x => x.Description, languageId, false, false);
                locale.MetaKeywords = category.GetLocalized(x => x.MetaKeywords, languageId, false, false);
                locale.MetaDescription = category.GetLocalized(x => x.MetaDescription, languageId, false, false);
                locale.MetaTitle = category.GetLocalized(x => x.MetaTitle, languageId, false, false);
                locale.Published = category.GetLocalized(x => x.Published, languageId, false, false);
            });
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Category = model.ToEntity();
                    var catService = new CategoryServices();
                    Category.UpdatedDate = DateTime.Now;
                    catService.Add(Category);
                    UpdateLocales(Category, model);
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
                var catService = new CategoryServices();
                catService.Delete(ids.First());
                return jsonResult();
            }
            catch (Exception ex)
            {
                return jsonResult(false, ex.Message);
            }
        }

        protected void UpdateLocales(Category category, CategoryModel model)
        {
            var _localizedEntityService = new LocalizedEntityService();

            foreach (var localized in model.Locales)
            {
                _localizedEntityService.SaveLocalizedValue(category,
                                                               x => x.Name,
                                                               localized.Name,
                                                               localized.LanguageId);

                _localizedEntityService.SaveLocalizedValue(category,
                                                           x => x.Description,
                                                           localized.Description,
                                                           localized.LanguageId);
                _localizedEntityService.SaveLocalizedValue(category,
                                                          x => x.Published,
                                                          localized.Published,
                                                          localized.LanguageId);

                _localizedEntityService.SaveLocalizedValue(category,
                                                           x => x.MetaKeywords,
                                                           localized.MetaKeywords,
                                                           localized.LanguageId);

                _localizedEntityService.SaveLocalizedValue(category,
                                                           x => x.MetaDescription,
                                                           localized.MetaDescription,
                                                           localized.LanguageId);

                _localizedEntityService.SaveLocalizedValue(category,
                                                           x => x.MetaTitle,
                                                           localized.MetaTitle,
                                                           localized.LanguageId);

            }
        }
    }
}