using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Invest.Services
{
    public class LocalizedEntityService
    {
        public virtual string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            var invest = new InvestContext();
            var query = from lp in invest.LocalizedProperty
                        where lp.LanguageId == languageId &&
                        lp.EntityId == entityId &&
                        lp.LocaleKeyGroup == localeKeyGroup &&
                        lp.LocaleKey == localeKey
                        select lp.LocaleValue;
            var localeValue = query.FirstOrDefault();
            if (localeValue == null)
                localeValue = "";
            return localeValue;
        }
    }
}
