using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public class Category_Picture_Mapping : BaseEntity
    {
        public int CategoryId { get; set; }
        public int PictureId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Category Category { get; set; }
    }
}
