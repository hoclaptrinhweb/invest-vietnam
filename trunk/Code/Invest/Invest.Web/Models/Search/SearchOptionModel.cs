using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invest.Web.Models.Search
{
    public class SearchOptionModel
    {
        public SearchOptionModel()
        {
            OrderType = 1;
            CategoryId = 0;
        }
        public string Key { get; set; }
        public int OrderType { get; set; }
        public int CategoryId { get; set; }
    }
}