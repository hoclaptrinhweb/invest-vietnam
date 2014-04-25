using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Invest.Core;
using Invest.Services;

namespace Invest.Web.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFiles(long? productid)
        {
            var savedFilename = "";
            var postedFileBase = Request.Files["Filedata"];
            savedFilename = ConfigurationManager.AppSettings["NewsImage_UploadPath"] + DateTime.Now.ToString("hhmmssddMMyy") + postedFileBase.FileName;
            postedFileBase.SaveAs(Server.MapPath(savedFilename));
            var picServices = new PictureServices();
            var Pic = new Picture();
            Pic.PathUrl = savedFilename;
            picServices.Add(Pic);
            return Content(Url.Content(savedFilename));
        }
    }
}