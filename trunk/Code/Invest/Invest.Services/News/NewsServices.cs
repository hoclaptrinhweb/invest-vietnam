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
        private InvestContext invest = new InvestContext();
        public IEnumerable<News> GetAll()
        {
            var result = invest.News.ToList();
            return result;
        }

        public void Add(News news)
        {
            if (news.Id == 0)
                invest.News.Add(news);
            else
                invest.Entry(news).State = System.Data.Entity.EntityState.Modified;
            invest.SaveChanges();
        }

        public void Add(int NewsID, string urlpath, int order)
        {
            var pic = new Picture();
            pic.PathUrl = urlpath;
            var picServices = new PictureServices();
            picServices.Add(pic);
            var picMap = new News_Picture_Mapping();
            picMap.NewsId = NewsID;
            picMap.DisplayOrder = order;
            picMap.PictureId = pic.Id;
            invest.News_Picture_Mapping.Add(picMap);
            invest.SaveChanges();
        }
    }
}
