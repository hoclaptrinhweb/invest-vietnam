using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public class News_Category_Mapping : BaseEntity
    {
        public int NewsId { get; set; }
        public int CategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Category Category { get; set; }
        public virtual News News { get; set; }
    }
}
