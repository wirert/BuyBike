namespace BuyBike.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using BuyBike.Infrastructure.Data.Configuraton;

    /// <summary>
    /// Application database context
    /// </summary>
    public class BuyBikeDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        private bool seedDb;

        public BuyBikeDbContext(DbContextOptions<BuyBikeDbContext> options, bool seedDb = true) : base(options)
        {
            this.seedDb = seedDb;
        }

        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;        
        public virtual DbSet<Bicycle> Bicycles { get; set; } = null!;        
        public virtual DbSet<Part> Parts { get; set; } = null!;        
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTptMappingStrategy();
                     

            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            base.OnModelCreating(modelBuilder);


            if (seedDb)
            {
                modelBuilder.ApplyConfiguration(new SeedManufacturersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedModelsAndBicyclesConfiguraton());
                modelBuilder.ApplyConfiguration(new SeedBicyclesEntityConfiguration());
            }
        }
    }
}
