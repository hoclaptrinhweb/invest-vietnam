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
    }
}
