namespace BuyBike.Api.Extentions
{
    using Microsoft.EntityFrameworkCore;
    using BuyBike.Core.Services;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data;
    using BuyBike.Infrastructure.Data.Common;


    /// <summary>
    /// Adds extention methods to the ServiceCollection of application
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add DataBase Server with connection string from configuration file
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BuyBikeDbContext>(options =>
            {
                options.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();
            });

            return services;
        }

        /// <summary>
        /// Register required services in the IoC container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicatonServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMinIoRepository, MinIoRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }       
    }
}
