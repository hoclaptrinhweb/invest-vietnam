using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Services;

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
            var cat = catService.GetCategoryByID(id);
            var name = cat.GetLocalized(x => x.Name, 1, false, false);
            var pub = cat.GetLocalized(x => x.Published, 1, false, false);
            if (cat == null)
                return HttpNotFound();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var catService = new CategoryServices();
                    catService.Add(Category);
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
    }
}