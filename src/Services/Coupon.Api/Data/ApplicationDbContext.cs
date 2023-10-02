using Coupon.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Models.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var listDefaultCoupons = new List<Models.Coupon>() {
                new Models.Coupon{ CouponId = 1, CouponCode = "10OFF", DiscountAmount = 10, MinAmount = 20 },
                new Models.Coupon{ CouponId = 2, CouponCode = "20OFF", DiscountAmount = 20, MinAmount = 20 }
            };
            modelBuilder.Entity<Models.Coupon>().HasData(listDefaultCoupons);
        }
    }
}
