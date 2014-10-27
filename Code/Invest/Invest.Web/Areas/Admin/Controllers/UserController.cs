﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Invest.Services;
using Invest.Core;
namespace Invest.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index(string currentFilter, string qr, int? key, int? page)
        {
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
                Email = n.Email,
                IsActive = n.IsActive,
                CreatedDate = n.CreatedDate
            }).OrderBy(n => n.CreatedDate);
            return View(result1.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Edit(int id = 0)
        {
            var userSv = new UserServices();
            var result = userSv.GetByID(id);
            if (result == null)
                result = new User();
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSv = new UserServices();
                    userSv.Add(user);
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
                    throw new Exception("Bạn chưa chọn !");
                var Slidersvc = new UserServices();
                Slidersvc.Delete(ids.First());
                return jsonResult();
            }
            catch (Exception ex)
            {
                return jsonResult(false, ex.Message);
            }
        }
    }
}