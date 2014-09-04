using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Web.Areas.Admin.Models;
using DataLayer;
using PagedList;
namespace Invest.Web.Areas.Admin.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {
            var test = new TestLanguage();
            return View(test);
        }

        public ActionResult ListUser()
        {
            var invest = new InvestContext();

            var result1 = invest.User.Select(n => new UserModel()
            {
                Id = n.Id,
                UserName = n.UserName,
                Password = n.Password,
                Email = n.Email,
                IsActive = n.IsActive,
                CreatedDate = n.CreatedDate
            }).OrderBy(n => n.CreatedDate);
            return PartialView(result1.ToPagedList(1, 4));
        }
    }
}