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
            this.News_NewsTag_Mapping = new HashSet<News_NewsTag_Mapping>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News_NewsTag_Mapping> News_NewsTag_Mapping { get; set; }
    }
}
