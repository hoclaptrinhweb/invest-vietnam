using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Invest.Core;

namespace DataLayer
{
    public class InvestContext : DbContext
    {
        public InvestContext() : base("Invest")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Language> Language { get; set; }


        public DbSet<News> News { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<News_Picture_Mapping> News_Picture_Mapping { get; set; }
        public DbSet<News_NewsTag_Mapping> News_NewsTag_Mapping { get; set; }
        public DbSet<News_Category_Mapping> News_Category_Mapping { get; set; }
        public DbSet<Category_Picture_Mapping> Category_Picture_Mapping { get; set; }

        public DbSet<LocalizedProperty> LocalizedProperty { get; set; }
        public DbSet<LocaleStringResource> LocaleStringResource { get; set; }
    }
}
