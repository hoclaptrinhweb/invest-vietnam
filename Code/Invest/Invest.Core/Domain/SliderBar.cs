using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public partial class SliderBar : BaseEntity
    {
        public SliderBar()
        {
            CreatedDate = DateTime.Now;
            DisplayOrder = 0;
        }
        public string ImageAlt { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLink { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
