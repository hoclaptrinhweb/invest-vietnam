﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;
using Invest.Web.Framework;

namespace Invest.Web.Areas.Admin.Models.Catalog
{
    public partial class CategoryModel : BaseEntity
    {
        public CategoryModel()
        {
            Locales = new List<CategoryLocalizedModel>();
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

        public IList<CategoryLocalizedModel> Locales { get; set; }

    }

    public partial class CategoryLocalizedModel : ILocalizedModelLocal
    {
    
        public CategoryLocalizedModel()
        {
            Published = true;
        }
        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }
        public bool Published { get; set; }

    }
}