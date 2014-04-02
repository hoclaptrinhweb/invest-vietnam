#region Using...

using System;
using System.IO;
using System.Web.Mvc;
using System.Web.WebPages;
using Invest.Core;

#endregion

namespace Invest.Web.Framework.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {

        private LocaleStringResource _localeResource;
        public Language _language;
        public 
        public override void InitHelpers()
        {
            base.InitHelpers();
            //Chỉnh lại ngôn ngữ
            _language = new Language();
            _language.Id = 1;
        }
    }



}