using System;
using System.Threading.Tasks;
using GallaSoft.RetailerOnboardingAPI.Model;
using GallaSoft.RetailerOnboardingAPI.Utility;
using GallaSoft.RetailerOnboardingAPI.ViewModels;

namespace GallaSoft.RetailerOnboardingAPI.Repository
{
    public interface IRetailerService
    {
        Task<int?> OnboardReatiler(RetailerVM newRetailer);

        Task<bool> UpdateStatus(int retailerId, Constants.Status status);

        Task<RetailerVM> GetRetailerById(int id);

        Task<RetailerVM> GetRetailerByGUID(string retailerGuid);

        Task<int?> GetRetailerStatus(string retailerGuid);

        Task<bool> UpdateRetailer(Retailer newRetailer);
    }
}
