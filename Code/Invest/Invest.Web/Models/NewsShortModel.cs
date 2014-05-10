using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class NewsShortModel : BaseEntity
    {
        public string Title { get; set; }
        public string Brief { get; set; }
        public string ImagePath { get; set; }

    }
}