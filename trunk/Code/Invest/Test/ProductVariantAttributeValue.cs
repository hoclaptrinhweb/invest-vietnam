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
    
    public partial class ProductVariantAttributeValue
    {
        public int Id { get; set; }
        public int ProductVariantAttributeId { get; set; }
        public int AttributeValueTypeId { get; set; }
        public int AssociatedProductId { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public int PictureId { get; set; }
    
        public virtual Product_ProductAttribute_Mapping Product_ProductAttribute_Mapping { get; set; }
    }
}
