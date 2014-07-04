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
            switch (Request.Form.GetValues("type")[0])
            {   
                case "1":
                savedFilename = ConfigurationManager.AppSettings["NewsImage_UploadPath"] + DateTime.Now.ToString("hhmmssddMMyy") + postedFileBase.FileName;
                    break;
                case "2":
                    savedFilename = ConfigurationManager.AppSettings["SlideImage_UploadPath"] + DateTime.Now.ToString("hhmmssddMMyy") + postedFileBase.FileName;
                    break;
                default :
                    savedFilename = ConfigurationManager.AppSettings["TmpImage_UploadPath"] + DateTime.Now.ToString("hhmmssddMMyy") + postedFileBase.FileName;
                    break;
            }
            postedFileBase.SaveAs(Server.MapPath(savedFilename));
            return Content(Url.Content(savedFilename));
        }
    }
}