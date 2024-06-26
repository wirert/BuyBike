﻿namespace BuyBike.Api.Extentions
{
    using BuyBike.Infrastructure.Contracts;
    using static System.Net.Mime.MediaTypeNames;

    public static class ApplicationBuilderExtention
    {
        /// <summary>
        /// Seed pictures in MinIO object store
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static async Task<IApplicationBuilder> SeedPictures(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateAsyncScope();

            var services = scopedServices.ServiceProvider;

            var repo = services.GetService<IMinIoRepository>();

            await repo!.EnsureCreated("buy-bike");
            var image = await repo!.FindAsync("buy-bike", "brand-logos/cross.jpg");

            if (image == null)
            {
                await SeedDataAsync(repo!);
            }

            return app;
        }

        private static async Task SeedDataAsync(IMinIoRepository repo)
        {

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/mountain/Epic_Expert_Morn_White.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Epic_Expert_Morn_White.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/mountain/Epic_Expert_Morn_White.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/mountain/FATHOM_1_29_ColorADesertSage.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "FATHOM_1_29_ColorADesertSage.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/mountain/FATHOM_1_29_ColorADesertSage.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "FATHOM_1_29_ColorBBlack_Charcoal.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/mountain/FATHOM_1_29_ColorBBlack_Charcoal.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/city/Nulane_Pro_28_Grey.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Nulane_Pro_28_Grey.png", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/city/Nulane_Pro_28_Grey.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/city/Touring_Pro_28_Silver.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Touring_Pro_28_Silver.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/city/Touring_Pro_28_Silver.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/kids/Boxer_12_blue.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Boxer_12_blue.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/kids/Boxer_12_blue.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/kids/Faro_12_black.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Faro_12_black.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/kids/Faro_12_black.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/road/Allez_E5_28_red.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Allez_E5_28_red.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/road/Allez_E5_28_red.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/bicycles/road/Litening_Aero_28_Blue.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Litening_Aero_28_Blue.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "bicycles/road/Litening_Aero_28_Blue.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/parts/forks/SR-26-M3020-P.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "SR-26-M3020-P.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "parts/forks/SR-26-M3020-P.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/parts/shifters/SH-SL-M360-3-L.jpeg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "SH-SL-M360-3-L.jpeg", fs.Name);

                await repo.AddAsync("buy-bike", "shifters/SH-SL-M360-3-L.jpeg", file);
            }


            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/cross.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "cross.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/cross.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/cube.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "cube.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/cube.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/giant.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "giant.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/giant.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/head.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "head.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/head.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/specialized.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "specialized.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/specialized.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/srsuntour-logo.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "srsuntour-logo.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/srsuntour-logo.png", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/brand-logos/shimano-logo.png"))
            {
                var file = new FormFile(fs, 0, fs.Length, "shimano-logo.png", fs.Name);

                await repo.AddAsync("buy-bike", "brand-logos/shimano-logo.png", file);
            }


            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/city-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "city-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/city-unsplash.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/ebikes-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "ebikes-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/ebikes-unsplash.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/kids-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "kids-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/kids-unsplash.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/mountain-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "mountain-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/mountain-unsplash.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/road-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "road-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/road-unsplash.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/bicycle-unsplash.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "bicycle-unsplash.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/bicycle-unsplash.jpg", file);
            }

            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/fork.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "fork.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/fork.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/Parts-Explained.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "Parts-Explained.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/Parts-Explained.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/gear-shifter.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "gear-shifter.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/gear-shifter.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/chain.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "chain.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/chain.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/accessory.jpg"))
            {
                var file = new FormFile(fs, 0, fs.Length, "accessory.jpg", fs.Name);

                await repo.AddAsync("buy-bike", "categories/accessory.jpg", file);
            }
            using (FileStream fs = File.OpenRead(@"Data/Pictures/categories/equpment.webp"))
            {
                var file = new FormFile(fs, 0, fs.Length, "equpment.webp", fs.Name);

                await repo.AddAsync("buy-bike", "categories/equpment.webp", file);
            }
        }
    }
}
