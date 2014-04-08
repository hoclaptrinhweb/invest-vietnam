using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Invest.Web.Framework.MVC;

namespace Invest.Web.Framework
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString NopLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, bool displayHint = true)
        {
            var result = new StringBuilder();
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var hintResource = string.Empty;
            object value = null;
        
            result.Append(helper.LabelFor(expression, new { title = hintResource }));
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
