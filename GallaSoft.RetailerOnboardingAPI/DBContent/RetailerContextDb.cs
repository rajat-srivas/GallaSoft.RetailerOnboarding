using System;
using GallaSoft.RetailerOnboardingAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GallaSoft.RetailerOnboardingAPI.DBContent
{
    public class RetailerContextDb : DbContext
    {

        public RetailerContextDb(DbContextOptions<RetailerContextDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
        public virtual DbSet<StatusMap> StatusMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusMap>().HasData(
                new StatusMap
                {
                    StatusId = 1,
                    Status = "Active"
                },
                new StatusMap
                {
                    StatusId = 2,
                    Status = "InActive"
                },
                 new StatusMap
                 {
                     StatusId = 3,
                     Status = "Pending"
                 }
            );
        }
    }
}
