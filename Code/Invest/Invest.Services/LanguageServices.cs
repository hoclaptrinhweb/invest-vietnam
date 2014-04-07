using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class LanguageServices
    {
        public Language GetLanguage(string value)
        {
            var invest = new InvestContext();
            var result = invest.Language.Where(l => l.LanguageCulture == value).FirstOrDefault();
            return result;
        }

        public IEnumerable<Language> GetAll()
        {
            var invest = new InvestContext();
            return invest.Language.ToList();
        }
    }
}
