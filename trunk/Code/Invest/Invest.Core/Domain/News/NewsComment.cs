using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Core
{
    public partial class NewsComment : BaseEntity
    {
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int NewsItemId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual News News { get; set; }
    }
}
