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
    
    public partial class ProductReview
    {
        public ProductReview()
        {
            this.ProductReviewHelpfulnesses = new HashSet<ProductReviewHelpfulness>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public bool IsApproved { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int HelpfulYesTotal { get; set; }
        public int HelpfulNoTotal { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnesses { get; set; }
    }
}