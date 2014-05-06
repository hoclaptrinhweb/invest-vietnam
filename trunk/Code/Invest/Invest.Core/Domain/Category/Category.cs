using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invest.Core
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            ParentCategoryId = 0;
            PictureId = 0;
            PageSize = 10;
            AllowCustomersToSelectPageSize = true;
            ShowOnHomePage = false;
            IncludeInTopMenu = false;
            Published = true;
            Deleted = false;
            DisplayOrder = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            this.News_Category_Mapping = new HashSet<News_Category_Mapping>();

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int ParentCategoryId { get; set; }
        public int PictureId { get; set; }
        public int PageSize { get; set; }
        public bool AllowCustomersToSelectPageSize { get; set; }
        public string PageSizeOptions { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<News_Category_Mapping> News_Category_Mapping { get; set; }

        
    }
}
