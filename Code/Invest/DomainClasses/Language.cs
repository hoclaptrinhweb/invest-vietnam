using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainClasses
{
    public  class Language
    {
        public Language()
        {
            this.LocaleStringResources = new HashSet<LocaleStringResource>();
            this.LocalizedProperties = new HashSet<LocalizedProperty>();
            LimitedToStores = false;
            Published = true;
            DisplayOrder = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<LocaleStringResource> LocaleStringResources { get; set; }
        public virtual ICollection<LocalizedProperty> LocalizedProperties { get; set; }
    }
}
