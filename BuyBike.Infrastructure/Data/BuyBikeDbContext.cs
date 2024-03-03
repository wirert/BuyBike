namespace BuyBike.Infrastructure.Data
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application database context
    /// </summary>
    public class BuyBikeDbContext(DbContextOptions<BuyBikeDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Bicycle> Bicycles { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<BicycleType> BicycleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
