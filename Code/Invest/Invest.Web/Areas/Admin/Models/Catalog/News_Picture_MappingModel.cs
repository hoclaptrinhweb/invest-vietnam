using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class News_Picture_MappingModel : BaseEntity
    {
        public string UrlPath { get; set; }
        public int DisplayOrder { get; set; }
    }
}