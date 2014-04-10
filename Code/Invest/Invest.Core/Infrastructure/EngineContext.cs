using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Invest.Core.Infrastructure
{
    public class EngineContext
    {
        public static Language WorkingLanguage
        {
            get
            {
                return (Language)HttpContext.Current.Items["Language"];
            }
            set
            {
                HttpContext.Current.Items["Language"] = value;
            }
        }
    }
}
