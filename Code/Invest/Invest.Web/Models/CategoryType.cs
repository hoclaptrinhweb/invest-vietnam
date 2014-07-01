using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invest.Web
{
    public class CategoryType
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<CategoryType> GetAll(bool IsAll)
        {
            var result = new List<CategoryType>();
            if (IsAll)
                result.Add(new CategoryType
                {
                    Name = "All",
                    Value = "-1"
                });
            result.Add(new CategoryType
            {
                Name = "News",
                Value = "1"
            });
            result.Add(new CategoryType
            {
                Name = "Maps",
                Value = "2"
            });
            return result;
        }
    }
}