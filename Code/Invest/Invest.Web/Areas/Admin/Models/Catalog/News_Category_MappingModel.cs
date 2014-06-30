using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class News_Category_MappingModel : BaseEntity
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public int DisplayOrder { get; set; }
    }
}