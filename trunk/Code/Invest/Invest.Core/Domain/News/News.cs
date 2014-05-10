using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public partial class News : BaseEntity
    {
        public News()
        {
            this.NewsComments = new HashSet<NewsComment>();
            this.News_Category_Mapping = new HashSet<News_Category_Mapping>();

            this.CreatedDate = DateTime.Now;
            this.StartDate = DateTime.Now;
            this.Published = true;
            this.AllowComments = true;
            this.CommentCount = 0;
            this.LanguageId = 1;
        }

        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }
        public string Tags { get; set; }
        public bool Published { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public bool AllowComments { get; set; }
        public int CommentCount { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
        public virtual ICollection<News_Category_Mapping> News_Category_Mapping { get; set; }
    }
}
