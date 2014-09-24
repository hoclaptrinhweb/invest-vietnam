using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invest.Web
{
    public class MetaNewsInfoModel : MetaInfoModel
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Manufacturer { get; set; }
        public string Tag { get; set; }
    }
}