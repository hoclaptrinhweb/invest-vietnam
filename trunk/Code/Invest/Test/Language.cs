//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        public Language()
        {
            this.BlogPosts = new HashSet<BlogPost>();
            this.LocaleStringResources = new HashSet<LocaleStringResource>();
            this.LocalizedProperties = new HashSet<LocalizedProperty>();
            this.News = new HashSet<News>();
            this.Polls = new HashSet<Poll>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Rtl { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
    
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        public virtual ICollection<LocaleStringResource> LocaleStringResources { get; set; }
        public virtual ICollection<LocalizedProperty> LocalizedProperties { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
    }
}
