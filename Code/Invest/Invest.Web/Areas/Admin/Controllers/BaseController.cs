using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Services;
using Invest.Web.Framework;

namespace Invest.Web.Areas.Admin.Controllers
{
    [Authorize]
    public abstract partial class BaseController : Controller
    {
        public JsonResult jsonResult(bool success = true, string message = "", bool allowGet = true)
        {
            if (allowGet)
                return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
            return Json(new { success = success, message = message, JsonRequestBehavior.DenyGet });
        }

        /// <summary>
        /// Add locales for localizable entities
        /// </summary>
        /// <typeparam name="TLocalizedModelLocal">Localizable model</typeparam>
        /// <param name="languageService">Language service</param>
        /// <param name="locales">Locales</param>
        protected virtual void AddLocales<TLocalizedModelLocal>(LanguageServices languageService, IList<TLocalizedModelLocal> locales) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            AddLocales(languageService, locales, null);
        }

        /// <summary>
        /// Add locales for localizable entities
        /// </summary>
        /// <typeparam name="TLocalizedModelLocal">Localizable model</typeparam>
        /// <param name="languageService">Language service</param>
        /// <param name="locales">Locales</param>
        /// <param name="configure">Configure action</param>
        protected virtual void AddLocales<TLocalizedModelLocal>(LanguageServices languageService, IList<TLocalizedModelLocal> locales, Action<TLocalizedModelLocal, int> configure) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            foreach (var language in languageService.GetAll())
            {
                var locale = Activator.CreateInstance<TLocalizedModelLocal>();
                locale.LanguageId = language.Id;
                if (configure != null)
                {
                    configure.Invoke(locale, locale.LanguageId);
                }
                locales.Add(locale);
            }
        }
    }
}