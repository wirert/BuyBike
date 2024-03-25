namespace BuyBike.Api.Extentions
{
    using BuyBike.Core.Services;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Minio;
    using Minio.AspNetCore;
    using PrintingHouse.Infrastructure.Data.Common;

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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBicyclesService, BicyclesService>();
            //services.AddScoped<IMinIoRepository, MinIoRepository>();

            return services;
        }

        /// <summary>
        /// Register and configure MinIO object storage
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMinIO(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMinioClient, MinioClient>(cfg => cfg.GetRequiredService<MinioClient>());
            
            services.AddMinio(options =>
            {
                options.Endpoint = configuration.GetValue<string>("MinIo:Endpoint")!;
                options.AccessKey = configuration.GetValue<string>("MinIo:AccessKey")!;
                options.SecretKey = configuration.GetValue<string>("MinIo:SecretKey")!;

                options.ConfigureClient(client =>
                {
                    client.WithEndpoint(options.Endpoint)
                        .WithCredentials(options.AccessKey, options.SecretKey)
                        .WithSSL(false)
                        .Build();
                });
            });

            return services;
        }
    }
}
