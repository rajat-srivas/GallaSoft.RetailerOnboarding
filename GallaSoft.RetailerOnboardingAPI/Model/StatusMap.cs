using System;
using System.Collections.Generic;

#nullable disable

namespace GallaSoft.RetailerOnboardingAPI.Model
{
    public partial class StatusMap
    {
        public StatusMap()
        {
            Retailers = new HashSet<Retailer>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Retailer> Retailers { get; set; }
    }
}
