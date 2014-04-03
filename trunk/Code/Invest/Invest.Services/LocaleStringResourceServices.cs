using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class LocaleStringResourceServices
    {
        public string GetResource(string value, int languageid)
        {
            InvestContext invest = new InvestContext();
            var result = invest.LocaleStringResource.Where(l => l.ResourceName == value && l.LanguageId == languageid).FirstOrDefault();
            if (result != null)
                return result.ResourceValue;
            else
                return value;
        }
    }
}
