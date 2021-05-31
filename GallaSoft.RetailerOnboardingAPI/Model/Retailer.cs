using System;
using System.Collections.Generic;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public partial class Retailer
    {
        public Guid RetailerGuid { get; set; }
        public string CompanyName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string EmailAddress { get; set; }
        public string AssetDirectory { get; set; }
        public int AddressId { get; set; }
        public int Status { get; set; }
        public string RetailerStatus { get; set; }
        public int RetailerId { get; set; }

        public virtual Address Address { get; set; }
        public virtual StatusMap StatusNavigation { get; set; }
    }
}
