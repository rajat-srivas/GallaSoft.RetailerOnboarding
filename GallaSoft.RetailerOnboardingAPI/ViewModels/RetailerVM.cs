using System;
using GallaSoft.RetailerOnboardingAPI.Model;

namespace GallaSoft.RetailerOnboardingAPI.ViewModels
{
    public class RetailerVM
    {
        public RetailerVM()
        {

        }
        public Retailer Retailer { get; set; }
        public Address Address { get; set; }
    }
}
