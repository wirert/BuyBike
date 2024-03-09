namespace BuyBike.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Account;

    /// <summary>
    /// Application database context
    /// </summary>
    public class BuyBikeDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
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
