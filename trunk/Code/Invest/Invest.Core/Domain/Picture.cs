using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public partial class Picture : BaseEntity
    {
        public Picture()
        {
            this.News_Picture_Mapping = new HashSet<News_Picture_Mapping>();
        }

        public byte[] PictureBinary { get; set; }
        public string PathUrl { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public bool IsNew { get; set; }

        public virtual ICollection<News_Picture_Mapping> News_Picture_Mapping { get; set; }
    }
}
