using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class NewsCategoryServices
    {
        public InvestContext invest = new InvestContext();

        public IEnumerable<News_Category_Mapping> GetNewsByCategory(int CatId)
        {
            var result = from m in invest.News_Category_Mapping
                         join n in invest.News on m.NewsId equals n.Id
                         join c in invest.Category on m.CategoryId equals c.Id
                         select m;
            var a = invest.Category_Picture_Mapping.ToList();

            return result;
        }
    }
}
