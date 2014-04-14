namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Invest.Core;

    public class Configuration : DbMigrationsConfiguration<DataLayer.InvestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataLayer.InvestContext context)
        {
            //  This method will be called after migrating to the latest version.
            try
            {
                var invest = new InvestContext();
                invest.Category.AddOrUpdate(
                    p => p.Name,
                    new Category { Name = "Why VietNam", DisplayOrder = 0, ParentCategoryId = 0 },
                    new Category { Name = "Industries", DisplayOrder = 1, ParentCategoryId = 0 },
                    new Category { Name = "Where to invest", DisplayOrder = 2, ParentCategoryId = 0 },
                    new Category { Name = "Doing Business", DisplayOrder = 3, ParentCategoryId = 0 },
                    new Category { Name = "Life in Korea", DisplayOrder = 4, ParentCategoryId = 0 },
                    new Category { Name = "Resources", DisplayOrder = 5, ParentCategoryId = 0 },
                    new Category { Name = "About Us", DisplayOrder = 6, ParentCategoryId = 0 },
                    new Category { Name = "Investment Consulting", DisplayOrder = 7, ParentCategoryId = 0 },

                    new Category { Name = "8 Reasons to Choose VietNam", DisplayOrder = 1, ParentCategoryId = 1 },
                    new Category { Name = "Success Stories", DisplayOrder = 2, ParentCategoryId = 1 },
                    new Category { Name = "Facts & Stats", DisplayOrder = 3, ParentCategoryId = 1 },

                    new Category { Name = "Parts and Materials", DisplayOrder = 1, ParentCategoryId = 2 },
                    new Category { Name = "Auto Parts", DisplayOrder = 1, ParentCategoryId = 2 },
                    new Category { Name = "Displays", DisplayOrder = 2, ParentCategoryId = 2 }

                    );
                invest.Language.AddOrUpdate(
                    p => p.Name,
                    new Language { Name = "English", LanguageCulture = "en-US", UniqueSeoCode = "en" },
                    new Language { Name = "Japan", LanguageCulture = "ja-JP", UniqueSeoCode = "ja" },
                    new Language { Name = "Korea", LanguageCulture = "ko-KR", UniqueSeoCode = "ko" }
                    );
                invest.LocaleStringResource.AddOrUpdate(
                    p => new { p.LanguageId, p.ResourceName },
                    new LocaleStringResource { LanguageId = 1, ResourceName = "Search", ResourceValue = "Search" },
                    new LocaleStringResource { LanguageId = 1, ResourceName = "Save", ResourceValue = "Save" },
                    new LocaleStringResource { LanguageId = 1, ResourceName = "Delete", ResourceValue = "Delete" },
                    new LocaleStringResource { LanguageId = 2, ResourceName = "Search", ResourceValue = "Tìm kiếm" },
                    new LocaleStringResource { LanguageId = 2, ResourceName = "Save", ResourceValue = "Lưu" },
                    new LocaleStringResource { LanguageId = 2, ResourceName = "Delete", ResourceValue = "Xóa" }
                    );
                invest.SaveChanges();
            }
            catch
            {
                var n = 0;
            }

        }
    }
}
