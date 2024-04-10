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
        //Seed Databases
        private bool seedDb;

        public BuyBikeDbContext(DbContextOptions<BuyBikeDbContext> options, bool seedDb = true) : base(options)
        {
            this.seedDb = seedDb;
        }

       public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ProductAttributeValue> AttributeValues { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
       public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(op => new { op.OrderId, op.ItemId });

            base.OnModelCreating(modelBuilder);


            if (seedDb)
            {
                modelBuilder.ApplyConfiguration(new SeedDiscountsConfiguration());
                modelBuilder.ApplyConfiguration(new SeedManufacturersEntityConfiguration());
                modelBuilder.ApplyConfiguration(new SeedItemsTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedTypesTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedAttributeTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedCategoriesTableConfiguration());
                modelBuilder.ApplyConfiguration(new SeedProductsTableConfiguration());   
                modelBuilder.ApplyConfiguration(new SeedAttributeValueConfiguration());   
                
            }
        }
    }
}
