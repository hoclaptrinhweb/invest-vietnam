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
    
    public partial class ExternalAuthenticationRecord
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string ExternalIdentifier { get; set; }
        public string ExternalDisplayIdentifier { get; set; }
        public string OAuthToken { get; set; }
        public string OAuthAccessToken { get; set; }
        public string ProviderSystemName { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
