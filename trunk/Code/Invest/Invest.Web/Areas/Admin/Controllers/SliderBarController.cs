using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Invest.Web.Areas.Admin.Controllers
{
    public class SliderBarController : BaseController
    {
        // GET: Admin/SliderBar
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

            var invest = new InvestContext();

            var result1 = invest.SliderBar.Select(n => new SliderBarModel()
            {
                Id = n.Id,
                ImageAlt = n.ImageAlt,
                ImageUrl = n.ImageUrl,
                ImageLink = n.ImageLink,
                CreatedDate = n.CreatedDate,
                DisplayOrder = n.DisplayOrder
            }).OrderBy(n => n.CreatedDate);
            return View(result1.ToPagedList(pageNumber, pageSize));

        }
    }
}