using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public partial class StatusMap
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Status { get; set; }

    }
}
