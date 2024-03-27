namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class SeedItemsTableConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                [
                    new Item()
                    {
                        Id = Guid.Parse("8e6b5a05-304d-4d4d-a1f9-bbd2e5d92809"),
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        InStock = 20,
                        Size = Size.L,
                        Sku = "ITM0000001"
                    },
                    new Item()
                    {
                        Id = Guid.Parse("5ed9dbe5-9b52-472c-8701-5bb4e47bfc88"),
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        InStock = 10,
                        Size = Size.XL,
                        Sku = "ITM0000002"
                    },
                    new Item()
                    {
                        Id = Guid.Parse("2f14708a-9fd7-498a-ab57-e207cb92bb02"),
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        InStock = 5,
                        Size = Size.M,
                        Sku = "ITM0000003"
                    },

                     new Item()
                    {
                        Id = Guid.Parse("899fc2be-85af-46c9-b1ca-c1bb256fdacf"),
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        InStock = 9,
                        Size = Size.M,
                        Sku = "ITM0000004"
                    },
                    new Item()
                    {
                        Id = Guid.Parse("69d4c6ac-225e-4280-99fb-58869eae5333"),
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        InStock = 33,
                        Size = Size.L,
                        Sku = "ITM0000005"
                    },

                     new Item()
                    {
                        Id = Guid.Parse("d99f6519-e62d-4653-a950-2ef8f896608d"),
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        InStock = 12,
                        Size = Size.L,
                        Sku = "ITM0000006"
                    },

                     new Item()
                    {
                        Id = Guid.Parse("ff30f42a-ec1d-42cd-a3b4-7b5658221d01"),
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        InStock = 18,
                        Size = Size.L,
                        Sku = "ITM0000007"
                    },
                    new Item()
                    {
                        Id = Guid.Parse("f1c54893-bdc1-4b37-baad-db033b2d359b"),
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        InStock = 0,
                        Size = Size.XL,
                        Sku = "ITM0000008"
                    },

                    new Item()
                    {
                        Id = Guid.Parse("62af2302-bbfc-48fe-80d2-273db4b3918b"),
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        InStock = 5,
                        Size = Size.S,
                        Sku = "ITM0000009"
                    },

                    new Item()
                    {
                        Id = Guid.Parse("e3ff3a7f-96ac-487c-888d-311bf73018e2"),
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        InStock = 14,
                        Size = Size.L,
                        Sku = "ITM0000010"
                    },

                    new Item()
                    {
                        Id = Guid.Parse("9a3c3435-f141-44d2-a7b5-2d408edb5b17"),
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        InStock = 7,
                        Size = Size.L,
                        Sku = "ITM0000011"
                    },

                     new Item()
                    {
                        Id = Guid.Parse("05fa52be-4af7-4923-8e35-9e337d1f7939"),
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                        InStock = 22,
                        Size = Size.Kids,
                        Sku = "ITM0000012"
                    },

                    new Item()
                    {
                        Id = Guid.Parse("a1b1b140-9a70-4bb9-8286-b46f8bdc41f3"),
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                        InStock = 17,
                        Size = Size.Kids,
                        Sku = "ITM0000013"
                    },
                ]);
        }
    }
}
