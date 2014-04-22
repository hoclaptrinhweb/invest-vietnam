using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class NewsModel : BaseEntity
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public bool Published { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}