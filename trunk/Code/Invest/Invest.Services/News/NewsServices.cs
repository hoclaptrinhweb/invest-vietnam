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

        public News GetNewsByID(int id)
        {
            var invest = new InvestContext();
            var result = invest.News.Where(l => l.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<News> GetNewsByCategory(int CatId)
        {
            var invest = new InvestContext();
         //   var result = from n in invest.News
                         //join  m in invest.News_Category_Mapping on n.Id equals m.NewsId
                         //join c in invest.Category on m.CategoryId equals c.Id
                         //where m.CategoryId == CatId
                         //select n;
            var result = invest.News.Where(n=> invest.News_Category_Mapping.Any(m=>m.NewsId == n.Id)).ToList();

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

        public void Add(News_Category_Mapping catMap)
        {
            invest.News_Category_Mapping.Add(catMap);
            invest.SaveChanges();
        }


    }
}
