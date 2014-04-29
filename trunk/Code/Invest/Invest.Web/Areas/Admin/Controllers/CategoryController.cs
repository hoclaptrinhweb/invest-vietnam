using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Services;
using Invest.Web.Areas.Admin.Models.Catalog;
using Invest.Web.Framework.MVC;
using PagedList;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        //
        // GET: /Admin/Category/
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

            var CategoryServices = new CategoryServices();
            var result = CategoryServices.GetAll();
            var data = result.Select(c =>
             {
                 var categoryModel = c.ToModel();
                 categoryModel.Name = c.GetFormattedBreadCrumb(CategoryServices);
                 return categoryModel;
             }).ToList();

            
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int id = 0)
        {
            var catService = new CategoryServices();

            var category = catService.GetCategoryByID(id);
            if (id == 0)
                category = new Category();
            var _languageService = new LanguageServices();
            var model = category.ToModel();
            model.ParentCategories = new List<DropDownItem> { new DropDownItem { Text = "[None]", Value = "0" } };
            if (model.ParentCategoryId > 0)
            {
                var parentCategory = catService.GetCategoryByID(model.ParentCategoryId);
                if (parentCategory != null && !parentCategory.Deleted)
                    model.ParentCategories.Add(new DropDownItem { Text = parentCategory.GetFormattedBreadCrumb(catService), Value = parentCategory.Id.ToString() });
                else
                    model.ParentCategoryId = 0;
            }
            AddLocales(_languageService, model.Locales, (locale, languageId) =>
            {
                locale.Name = category.GetLocalized(x => x.Name, languageId, false, false);
                locale.Description = category.GetLocalized(x => x.Description, languageId, false, false);
                locale.MetaKeywords = category.GetLocalized(x => x.MetaKeywords, languageId, false, false);
                locale.MetaDescription = category.GetLocalized(x => x.MetaDescription, languageId, false, false);
                locale.MetaTitle = category.GetLocalized(x => x.MetaTitle, languageId, false, false);
                locale.Published = category.GetLocalized(x => x.Published, languageId, false, false);
            });
            PrepareTemplatesModel(model);

            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
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

        protected void PrepareTemplatesModel(CategoryModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            var catService = new CategoryServices();

            var result = catService.GetAll();
            var data = result.Select(c => new SelectListItem()
                {
                    Text = c.GetFormattedBreadCrumb(catService),
                    Value = c.Id.ToString()
                }
            ).ToList();
            data.Insert(0, new SelectListItem() { Text = "None", Value = "0" });
            model.AvailableCategoryTemplates = data;

            var newsServices = new NewsServices();
            model.CategoryProductModel = catService.GetProductCategoriesByCategoryId(model.Id).Select(x =>
                 new CategoryProductModel()
                    {
                        Id = x.Id,
                        CategoryId = x.CategoryId,
                        NewsId = x.NewsId,
                        NewsName = newsServices.GetNewsByID(x.NewsId).Title,
                        DisplayOrder1 = x.DisplayOrder
                    }
                ).ToList();
        }
    }
}