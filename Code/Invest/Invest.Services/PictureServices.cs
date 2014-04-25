using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class PictureServices
    {


        public Picture GetPictureByID(int id)
        {
            var invest = new InvestContext();
            var result = invest.Picture.Where(l => l.Id == id).FirstOrDefault();
            return result;
        }

        public void Delete(int id)
        {
            var invest = new InvestContext();
            var dbEnty = invest.Picture.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Ngôn ngữ này hiện tại không tồn tại trong hệ thống");
            else
            {
                invest.Picture.Remove(dbEnty);
                invest.SaveChanges();
            }
        }

        public void Add(Picture Picture)
        {
            var invest = new InvestContext();
            if (Picture.Id == 0)
                invest.Picture.Add(Picture);
            else
                invest.Entry(Picture).State = System.Data.Entity.EntityState.Modified;
            invest.SaveChanges();
        }
    }
}
