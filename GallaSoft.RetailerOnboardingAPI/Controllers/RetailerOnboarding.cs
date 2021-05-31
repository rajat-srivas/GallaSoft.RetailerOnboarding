using System;
using System.Threading.Tasks;
using GallaSoft.RetailerOnboardingAPI.Model;
using GallaSoft.RetailerOnboardingAPI.Repository;
using GallaSoft.RetailerOnboardingAPI.Utility;
using GallaSoft.RetailerOnboardingAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GallaSoft.RetailerOnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/retailer")]
    public class RetailerOnboarding : ControllerBase
    {
        IRetailerService _retailer = null;
        public RetailerOnboarding(IRetailerService retailerService)
        {
            _retailer = retailerService;
        }

        [HttpPost]
        [Route("onboard")]
        public async Task<IActionResult> OnboardRetailer(RetailerVM newRetailer)
        {
            var createdRetailerId = await _retailer.OnboardReatiler(newRetailer);
            if (createdRetailerId != null)
                return Ok(createdRetailerId);
            else
                return BadRequest("Snap, something went wrong");
        }

        [HttpPut]
        [Route("status/{id}")]
        public async Task<IActionResult> UpdateRetailerStatus(int id, Constants.Status status)
        {
            var updateStatus = await _retailer.UpdateStatus(id, status);
            return updateStatus ? NoContent() : BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRetailerById(int id)
        {
            var retailer = await _retailer.GetRetailerById(id);
            return retailer != null ? Ok(retailer) : BadRequest("Something went wrong or the retailer no longer exist with this id");

        }

        [HttpGet]
        [Route("guid")]
        public async Task<IActionResult> GetRetailerByGuid(string guid)
        {
            var retailer = await _retailer.GetRetailerByGUID(guid);
            return retailer != null ? Ok(retailer) : BadRequest("Something went wrong or the retailer no longer exist with this guid");

        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetRetailerStatus(string guid)
        {
            var retailer = await _retailer.GetRetailerStatus(guid);
            return retailer != null ? Ok(retailer) : BadRequest("Something went wrong or the retailer no longer exist with this guid");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateRetailer(Retailer retailer)
        {
            var updateSuccess = await _retailer.UpdateRetailer(retailer);
            if (updateSuccess)
                return NoContent();
            else
                return BadRequest("Something went wrong");
        }
    }
}
