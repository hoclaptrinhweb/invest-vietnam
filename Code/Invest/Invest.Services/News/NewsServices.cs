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
    }
}
