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

        public Language GetLanguageByID(int id)
        {
            var invest = new InvestContext();
            var result = invest.Language.Where(l => l.Id == id).FirstOrDefault();
            return result;
        }



        public IEnumerable<Language> GetAll()
        {
            var invest = new InvestContext();
            return invest.Language.ToList();
        }

        public void Delete(int id)
        {
            var invest = new InvestContext();
            var dbEnty = invest.Language.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Ngôn ngữ này hiện tại không tồn tại trong hệ thống");
            else
            {
                invest.Language.Remove(dbEnty);
                invest.SaveChanges();
            }
        }

        public void Add(Language language)
        {
            var invest = new InvestContext();
            if (language.Id == 0)
            {
                invest.Language.Add(language);
            }
            else
            {
                invest.Entry(language).State = System.Data.Entity.EntityState.Modified;
            }
            invest.SaveChanges();
        }
    }
}
