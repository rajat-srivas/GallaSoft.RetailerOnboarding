using System;
using GallaSoft.RetailerOnboardingAPI.DBContent;
using GallaSoft.RetailerOnboardingAPI.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GallaSoft.RetailerOnboardingAPI.Utility
{
    public  static class ConfigureDependencies
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IRetailerService, RetailerService>();
        }
    }
}
