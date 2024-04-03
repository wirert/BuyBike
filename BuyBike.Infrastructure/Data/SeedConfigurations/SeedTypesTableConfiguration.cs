namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
   

    internal class SeedTypesTableConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                [
                new ProductType(){
                    Id = 1,
                    Name = "Велосипеди",
                    ImageUrl = "categories/bicycle-unsplash.jpg",
                    Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima. Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima."
                },
                new ProductType(){
                    Id = 2,
                    Name = "Части",
                    ImageUrl = "categories/Parts-Explained.jpg",
                    Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima."
                },
                new ProductType(){
                    Id = 3,
                    Name = "Аксесоари",
                    ImageUrl = "categories/accessory.jpg"
                },
                 new ProductType(){
                    Id = 4,
                    Name = "Екипировка",
                    ImageUrl = "categories/equpment.webp",
                     Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima. Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima. Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima. Lorem, ipsum dolor sit amet consectetur adipisicing elit. Culpa ullam repellat obcaecati consequuntur ut, quis quaerat recusandae tenetur magni illum. Eum et maxime aliquam assumenda tenetur, quis dicta nulla minima."
                },
                ]);
        }
    }
}
