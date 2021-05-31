using System;
using System.Threading.Tasks;
using GallaSoft.RetailerOnboardingAPI.DBContent;
using GallaSoft.RetailerOnboardingAPI.Model;
using GallaSoft.RetailerOnboardingAPI.Utility;
using GallaSoft.RetailerOnboardingAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GallaSoft.RetailerOnboardingAPI.Repository
{
    public class RetailerService : IRetailerService
    {
        private readonly RetailerContextDb _context;
        private readonly ILogger _logging;
        public RetailerService( ILoggerFactory logger, RetailerContextDb contextDb)
        {
            _logging = logger.CreateLogger<RetailerService>();
            _context = contextDb;
        }

        public async Task<RetailerVM> GetRetailerById(int id)
        {
            try
            {
                RetailerVM retailerDetails = new RetailerVM();
                retailerDetails.Retailer = await _context.Retailers.FirstOrDefaultAsync(x => x.RetailerId == id);

                if(retailerDetails.Retailer != null)
                {
                    retailerDetails.Address = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == retailerDetails.Retailer.AddressId);
                }

                return retailerDetails;
            }
            catch(Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return null;
            }
        }

        public async Task<RetailerVM> GetRetailerByGUID(string retailerGuid)
        {
            try
            {
                RetailerVM retailerDetails = new RetailerVM();
                retailerDetails.Retailer = await _context.Retailers.FirstAsync(x => x.RetailerGuid == Guid.Parse(retailerGuid));

                if (retailerDetails.Retailer != null)
                {
                    retailerDetails.Address = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == retailerDetails.Retailer.AddressId);
                }

                return retailerDetails;
            }
            catch (Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return null;
            }
        }

        public async Task<int?> OnboardReatiler(RetailerVM newRetailer)
        {
            try
            {
                _logging.LogInformation($"Onboarding new retailer {newRetailer.Retailer.CompanyName}");

                Address addressToCreate = newRetailer.Address;

                await _context.Addresses.AddAsync(addressToCreate);
                await _context.SaveChangesAsync();

                Retailer retailerToCreate = newRetailer.Retailer;

                retailerToCreate.RetailerGuid = Guid.NewGuid();
                retailerToCreate.AssetDirectory = $"{retailerToCreate.CompanyName.Substring(0,retailerToCreate.CompanyName.IndexOf(" "))}_{addressToCreate.Pincode}";
                retailerToCreate.Status = (int)Constants.Status.Active;
                retailerToCreate.AddressId = addressToCreate.AddressId;
                await _context.Retailers.AddAsync(retailerToCreate);
                await _context.SaveChangesAsync();


                _logging.LogInformation("Onbording completed");
                return retailerToCreate.RetailerId;
            }
            catch (Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return null;
            }
        }

        public async Task<bool> UpdateStatus(int retailerId, Constants.Status status)
        {
            try
            {
                _logging.LogInformation("Update retailer status started...");
                var retailerToUpdate = await _context.Retailers.FirstOrDefaultAsync(x => x.RetailerId == retailerId);
                if (retailerToUpdate == null)
                {
                    _logging.LogInformation($"Retailer with {retailerId} not found");
                    return false;
                }
                else
                {
                    retailerToUpdate.Status = (int)status;
                    _context.Retailers.Update(retailerToUpdate);
                    await _context.SaveChangesAsync();
                    _logging.LogInformation($"Retailer status updation completed for {retailerToUpdate.CompanyName}");
                    return true;
                }

            }
            catch (Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return false;
            }
        }

        public async Task<int?> GetRetailerStatus(string retailerGuid)
        {
            try
            {
                var retailer = await _context.Retailers.FirstAsync(x => x.RetailerGuid == Guid.Parse(retailerGuid));
                return retailer?.Status;
            }
            catch (Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return null;
            }
        }

        public async Task<bool> UpdateRetailer(Retailer retailer)
        {
            try
            {
                _logging.LogInformation("Update retailer started...");
                var retailerToUpdate = await _context.Retailers.FirstOrDefaultAsync(x => x.RetailerId == retailer.RetailerId);
                if (retailerToUpdate == null)
                {
                    _logging.LogInformation($"Retailer with {retailer.RetailerId} not found");
                    return false;
                }
                else
                {
                    retailerToUpdate.CompanyName = retailer.CompanyName;
                    retailerToUpdate.ContactFirstName = retailer.ContactFirstName;
                    retailerToUpdate.ContactLastName = retailer.ContactLastName;
                    retailerToUpdate.EmailAddress = retailer.EmailAddress;
                    retailerToUpdate.Status = retailer.Status;
                    _context.Retailers.Update(retailerToUpdate);
                    await _context.SaveChangesAsync();
                    _logging.LogInformation($"Retailer updation completed for {retailerToUpdate.CompanyName}");
                    return true;
                }

            }
            catch (Exception ex)
            {
                _logging.LogError(ex.StackTrace.ToString() + Environment.NewLine + ex.Message.ToString());
                return false;
            }
        }
    }
}
