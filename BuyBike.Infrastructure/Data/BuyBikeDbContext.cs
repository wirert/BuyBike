namespace BuyBike.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.SeedConfigurations;

    /// <summary>
    /// Application database context
    /// </summary>
    public class BuyBikeDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        //Seed Databases (in delvelopment)
        private bool seedDb;        

        public BuyBikeDbContext(DbContextOptions<BuyBikeDbContext> options, bool seedDb = true) : base(options)
        {
            this.seedDb = seedDb;
        }

        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        public virtual DbSet<ProductCategory> ProductsCategories { get; set; } = null!;
        public virtual DbSet<ProductAttributeValue> AttributeValues { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;        
        public virtual DbSet<Bicycle> Bicycles { get; set; } = null!;        
        public virtual DbSet<Part> Parts { get; set; } = null!;        
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderProducts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTptMappingStrategy();
                     

            modelBuilder.Entity<OrderItem>().HasKey(op => new { op.OrderId, op.ItemId });

            modelBuilder.Entity<ProductAttributeValue>().HasKey(pav => new { pav.ProductId, pav.AttributeId });

            base.OnModelCreating(modelBuilder);


            if (seedDb)
            {
                modelBuilder.ApplyConfiguration(new SeedDiscountsConfiguration());
                modelBuilder.ApplyConfiguration(new SeedManufacturersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedItemsTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedProductsCategoriesTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedBicyclesEntityConfiguration());
            }
        }
    }
}
