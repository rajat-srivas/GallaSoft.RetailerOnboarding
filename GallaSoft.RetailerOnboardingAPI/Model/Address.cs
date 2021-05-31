using System;
using System.Collections.Generic;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public partial class Address
    {
        public Address()
        {
            Retailers = new HashSet<Retailer>();
        }

        public int AddressId { get; set; }
        public string ContactAddress { get; set; }
        public string ContactAddress2 { get; set; }
        public string ContactCity { get; set; }
        public string ContactState { get; set; }
        public int? Pincode { get; set; }

        public virtual ICollection<Retailer> Retailers { get; set; }
    }
}
