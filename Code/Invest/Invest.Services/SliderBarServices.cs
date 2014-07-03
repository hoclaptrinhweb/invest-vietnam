using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class SliderBarServices
    {


        public Language GetByID(int id)
        {
            var invest = new InvestContext();
            var result = invest.Language.Where(l => l.Id == id).FirstOrDefault();
            return result;
        }
        public IEnumerable<SliderBar> GetAll()
        {
            var invest = new InvestContext();
            return invest.SliderBar.ToList();
        }

        public void Delete(int id)
        {
            var invest = new InvestContext();
            var dbEnty = invest.SliderBar.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Không tồn tại trong hệ thống");
            else
            {
                invest.SliderBar.Remove(dbEnty);
                invest.SaveChanges();
            }
        }

        public void Add(SliderBar language)
        {
            var invest = new InvestContext();
            if (language.Id == 0)
            {
                invest.SliderBar.Add(language);
            }
            else
            {
                invest.Entry(language).State = System.Data.Entity.EntityState.Modified;
            }
            invest.SaveChanges();
        }
    }
}
