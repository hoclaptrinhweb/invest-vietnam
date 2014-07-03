using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Web.Framework;
using Invest.Web.Framework.MVC;

namespace Invest.Web
{
    public partial class SliderBarModel : BaseEntity
    {
        public SliderBarModel()
        {
        }
        public string ImageAlt { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLink { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}