using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public class NewsTag : BaseEntity
    {
        public NewsTag()
        {
            this.News = new HashSet<News>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
