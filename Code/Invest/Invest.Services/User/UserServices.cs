using DataLayer;
using Invest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services
{
    public class UserServices
    {
        public void Delete(int id)
        {
            var invest = new InvestContext();
            var dbEnty = invest.User.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Không tồn tại trong hệ thống");
            else
            {
                invest.User.Remove(dbEnty);
                invest.SaveChanges();
            }
        }

        public void Add(User language)
        {
            var invest = new InvestContext();
            if (language.Id == 0)
            {
                invest.User.Add(language);
            }
            else
            {
                invest.Entry(language).State = System.Data.Entity.EntityState.Modified;
            }
            invest.SaveChanges();
        }

        public bool IsLogin(User user)
        {
            var invest = new InvestContext();
            var result = invest.User
                                .Where(u => u.UserName == user.UserName && u.Password == user.Password)
                                .FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }
    }
}
