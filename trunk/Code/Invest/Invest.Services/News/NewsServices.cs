using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class NewsServices
    {
        public IEnumerable<News> GetAll()
        {
            var invest = new InvestContext();
            var result = invest.News.ToList();
            return result;
        }

        public void Add(News news)
        {
            var invest = new InvestContext();
            if (news.Id == 0)
                invest.News.Add(news);
            else
                invest.Entry(news).State = System.Data.Entity.EntityState.Modified;
            invest.SaveChanges();
        }
    }
}
