using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public class News_NewsTag_Mapping : BaseEntity
    {
        public int NewsId { get; set; }
        public int NewsTagId { get; set; }
        public virtual NewsTag NewsTags { get; set; }
        public virtual News News { get; set; }
    }
}
