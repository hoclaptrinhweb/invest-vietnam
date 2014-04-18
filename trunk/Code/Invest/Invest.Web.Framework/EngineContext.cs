using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Invest.Core;
using Invest.Services;

namespace Invest.Web.Framework
{
    public class EngineContext
    {
        public static Language WorkingLanguage
        {
            get
            {
                if (HttpContext.Current.Items["Language"] != null)

                    return (Language)HttpContext.Current.Items["Language"];
                else
                {
                    var _languageServices = new LanguageServices();
                    var _language = _languageServices.GetLanguage(Thread.CurrentThread.CurrentUICulture.Name);
                    if (_language == null)
                    {
                        _language = new Language();
                        _language.Id = 1; // Mặc định
                    }
                    return _language;
                }
            }
            set
            {
                HttpContext.Current.Items["Language"] = value;
            }
        }
    }
}
