﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Invest.Web.Controllers
{
    public class CommonController : BaseController
    {

        public ActionResult Search(string key)
        {
            return View();
        }
    }
}