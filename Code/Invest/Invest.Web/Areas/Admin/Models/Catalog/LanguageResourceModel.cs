using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Invest.Core;

namespace Invest.Web
{
    public class LanguageResourceModel : BaseEntity
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string LanguageName { get; set; }

        public int LanguageId { get; set; }
    }
}