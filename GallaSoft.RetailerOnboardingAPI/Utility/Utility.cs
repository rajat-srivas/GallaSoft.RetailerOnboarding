using System;
namespace GallaSoft.RetailerOnboardingAPI.Utility
{
    public class Utility
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        public Utility(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }

    public static class Constants
    {
        public enum Status
        {
            Active = 1,
            Pending = 2,
            Inactive = 3
        }
    }
}
