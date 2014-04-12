using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Invest.Core;

namespace Invest.Services
{
    public class CategoryServices
    {
        public IEnumerable<Category> GetAllByParent(int ParentId)
        {
            var invest = new InvestContext();
            var result = invest.Category.Where(c => c.ParentCategoryId == ParentId).OrderBy(c => c.DisplayOrder).ThenBy(c => c.Name).ToList();
            return result;
        }

        public Category GetCategoryByID(int id)
        {
            var invest = new InvestContext();
            var result = invest.Category.Where(l => l.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<Category> GetAll()
        {
            var invest = new InvestContext();
            var unsortedCategories = invest.Category.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder).ToList();
            var sortedCategories = unsortedCategories.SortCategoriesForTree();
            return sortedCategories;
        }
        public void Delete(int id)
        {
            var invest = new InvestContext();
            var dbEnty = invest.Category.FirstOrDefault(l => l.Id == id);
            if (dbEnty == null)
                throw new Exception("Ngôn ngữ này hiện tại không tồn tại trong hệ thống");
            else
            {
                invest.Category.Remove(dbEnty);
                invest.SaveChanges();
            }
        }

        public void Add(Category Category)
        {
            var invest = new InvestContext();
            if (Category.Id == 0)
                invest.Category.Add(Category);
            else
                invest.Entry(Category).State = System.Data.Entity.EntityState.Modified;
            invest.SaveChanges();
        }
    }
}
