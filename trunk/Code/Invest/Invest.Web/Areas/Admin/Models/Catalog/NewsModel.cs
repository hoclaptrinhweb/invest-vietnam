using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invest.Core;

namespace Invest.Web
{
    public class NewsModel : BaseEntity
    {
        public NewsModel()
        {
            CreatedDate = DateTime.Now;
            AllowComments = true;
            Published = true;
            CommentCount = 0;
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
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

        public IList<SelectListItem> AvailableLanguages { get; set; }

    }
}