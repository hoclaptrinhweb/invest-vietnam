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
    
    public partial class Product_ProductAttribute_Mapping
    {
        public Product_ProductAttribute_Mapping()
        {
            this.ProductVariantAttributeValues = new HashSet<ProductVariantAttributeValue>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
        public virtual ICollection<ProductVariantAttributeValue> ProductVariantAttributeValues { get; set; }
    }
}
