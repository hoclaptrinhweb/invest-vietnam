using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Invest.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
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
            var result1 = invest.User.Select(n => new UserModel()
            {
                Id = n.Id,
                UserName = n.UserName,
                Password = n.Password,
                IsActive = n.IsActive,
                CreatedDate = n.CreatedDate
            }).OrderBy(n => n.CreatedDate);
            return View(result1.ToPagedList(pageNumber, pageSize));

        }
    }
}