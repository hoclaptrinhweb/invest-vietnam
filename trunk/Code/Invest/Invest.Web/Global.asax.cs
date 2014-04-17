using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DataLayer;
using DataLayer.Migrations;

namespace Invest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Nếu chạy lần đầu thì sử dụng cái này hoặc nếu thay đổi model,db
            // Luôn luôn chạy hàm này cũng được nhưng ko cần thiết nó sẽ làm chậm lúc start

            CreateDatabase();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            CheckLanguage();
        }

        public void CheckLanguage()
        {
            var handler = Context.Handler as MvcHandler;
            var routeData = handler != null ? handler.RequestContext.RouteData : null;
            var routeCulture = routeData != null ? (routeData.Values["culture"] != null ? routeData.Values["culture"].ToString() : null) : null;
            var languageCookie = HttpContext.Current.Request.Cookies["lang"];
            var userLanguages = HttpContext.Current.Request.UserLanguages;

            // Set the Culture based on a route, a cookie or the browser settings,
            // or default value if something went wrong
            if (routeCulture != null)
            {
                var cultureInfo = new CultureInfo(
                    routeCulture ?? (languageCookie != null
                       ? languageCookie.Value
                       : userLanguages != null
                           ? userLanguages[0]
                           : "en")
                );
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
            }
            else
            {
                if (languageCookie != null)
                {
                    var cultureInfo = new CultureInfo(languageCookie.Value);
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                }

            }
        }

        public void CreateDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InvestContext, Configuration>());
            var invest = new InvestContext();
            invest.Database.Initialize(true);
        }
    }
}
