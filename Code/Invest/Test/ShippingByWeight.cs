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
    
    public partial class ShippingByWeight
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CountryId { get; set; }
        public int StateProvinceId { get; set; }
        public string Zip { get; set; }
        public int ShippingMethodId { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal AdditionalFixedCost { get; set; }
        public decimal PercentageRateOfSubtotal { get; set; }
        public decimal RatePerWeightUnit { get; set; }
        public decimal LowerWeightLimit { get; set; }
    }
}
