#region Using...

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using System.Web.WebPages;
using Invest.Core;
using Invest.Core.Infrastructure;
using Invest.Services;

#endregion

namespace Invest.Web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {

        private LocaleStringResourceServices _localeResourceServices;
        private LanguageServices _languageServices;
        public Language _language;
        public string Resource(string value)
        {
            return _localeResourceServices.GetResource(value, EngineContext.WorkingLanguage.Id);
        }
        public override void InitHelpers()
        {
            base.InitHelpers();
            //Chỉnh lại ngôn ngữ
            _localeResourceServices = new LocaleStringResourceServices();
            _languageServices = new LanguageServices();
            _language = _languageServices.GetLanguage(Thread.CurrentThread.CurrentUICulture.Name);
            if (_language == null)
            {
                _language = new Language();
                _language.Id = 1; // Mặc định
            }
            EngineContext.WorkingLanguage = _language;
        }
    }



}