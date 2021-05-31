using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public partial class Retailer
    {
        [Required]
        public Guid RetailerGuid { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactFirstName { get; set; }

        [Required]
        public string ContactLastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string AssetDirectory { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [ForeignKey("StatusMap")]
        public int Status { get; set; }

        [Key]
        public int RetailerId { get; set; }
    }
}
