using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string ContactAddress { get; set; }
        public string ContactAddress2 { get; set; }

        [Required]
        public string ContactCity { get; set; }

        [Required]
        public string ContactState { get; set; }

        
        public int? Pincode { get; set; }
    }
}
