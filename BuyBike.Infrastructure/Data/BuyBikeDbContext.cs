namespace BuyBike.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities;

    /// <summary>
    /// Application database context
    /// </summary>
    public class BuyBikeDbContext : IdentityDbContext<IdentityUser>
    {
        public BuyBikeDbContext(DbContextOptions<BuyBikeDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Bicycle> Bicycles { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
