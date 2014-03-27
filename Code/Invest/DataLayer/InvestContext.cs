using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DomainClasses;

namespace DataLayer
{
    public class InvestContext : DbContext
    {
        public InvestContext() : base("Invest") { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LocalizedProperty> LocalizedProperty { get; set; }
        public DbSet<LocaleStringResource> LocaleStringResource { get; set; }
    }
}
