using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class CategoryContentModel : BaseEntity
    {
        public IList<NewsCategoryViewModel> NewsCategoryViewModel { get; set; }
        public IList<CategoryModel> Category { get; set; }
    }
}