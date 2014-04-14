using System;
using System.Collections.Generic;
using System.Linq;
using Invest.Core;

namespace ConsoleTest.Catalog
{
    public partial class CategoryModel : BaseEntity
    {
        public CategoryModel()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

    }

    public partial class CategoryLocalizedModel : BaseEntity
    {
        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }
    }
}