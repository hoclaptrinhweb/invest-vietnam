using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public class News_Picture_Mapping : BaseEntity
    {
        public int NewsId { get; set; }
        public int PictureId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual News News { get; set; }
    }
}
