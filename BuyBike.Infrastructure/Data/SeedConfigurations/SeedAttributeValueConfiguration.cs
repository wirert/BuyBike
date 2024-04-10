namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SeedAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasData(
                [
                    //TyreSize
                    new ProductAttributeValue()
                    {
                        Id = 1,
                        AttributeId = 1,
                        Value = "29",
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 2,
                        AttributeId = 1,
                        Value = "29",
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 3,
                        AttributeId = 1,
                        Value = "29",
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 4,
                        AttributeId = 1,
                        Value = "28",
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    },
                     new ProductAttributeValue()
                    {
                        Id = 5,
                        AttributeId = 1,
                        Value = "28",
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 6,
                        AttributeId = 1,
                        Value = "28",
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 7,
                        AttributeId = 1,
                        Value = "28",
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 8,
                        AttributeId = 1,
                        Value = "12",
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 9,
                        AttributeId = 1,
                        Value = "12",
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    },

                    //Material
                    new ProductAttributeValue()
                    {
                        Id = 10,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 11,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 12,
                        AttributeId = 2,
                        Value = "Kарбон",
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 13,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    },
                     new ProductAttributeValue()
                    {
                        Id = 14,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 15,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 16,
                        AttributeId = 2,
                        Value = "Kарбон",
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 17,
                        AttributeId = 2,
                        Value = "Aлуминий",
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 18,
                        AttributeId = 2,
                        Value = "Стомана",
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    },

                    //Brakes
                    new ProductAttributeValue()
                    {
                        Id = 19,
                        AttributeId = 3,
                        Value = "Дискови",
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 20,
                        AttributeId = 3,
                        Value = "Дискови",
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 21,
                        AttributeId = 3,
                        Value = "Дискови",
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 22,
                        AttributeId = 3,
                        Value = "V-Brake",
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    },
                     new ProductAttributeValue()
                    {
                        Id = 23,
                        AttributeId = 3,
                        Value = "V-Brake",
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 24,
                        AttributeId = 3,
                        Value = "V-Brake",
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 25,
                        AttributeId = 3,
                        Value = "Дискови",
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 26,
                        AttributeId = 3,
                        Value = "Дискови",
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 27,
                        AttributeId = 3,
                        Value = "V-Brake",
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    },

                    //Suspention
                    new ProductAttributeValue()
                    {
                        Id = 28,
                        AttributeId = 4,
                        Value = "Амортисьорна вилка",
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 29,
                        AttributeId = 4,
                        Value = "Амортисьорна вилка",
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 30,
                        AttributeId = 4,
                        Value = "Пълно окачване",
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 31,
                        AttributeId = 4,
                        Value = "Твърда вилка",
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    },
                     new ProductAttributeValue()
                    {
                        Id = 32,
                        AttributeId = 4,
                        Value = "Твърда вилка",
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 33,
                        AttributeId = 4,
                        Value = "Амортисьорна вилка",
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 34,
                        AttributeId = 4,
                        Value = "Амортисьорна вилка",
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 35,
                        AttributeId = 4,
                        Value = "Амортисьорна вилка",
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 36,
                        AttributeId = 4,
                        Value = "Твърда вилка",
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                    },

                    //Style
                    new ProductAttributeValue()
                    {
                        Id = 37,
                        AttributeId = 5,
                        Value = "Крос кънтри / XC",
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 38,
                        AttributeId = 5,
                        Value = "Крос кънтри / XC",
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 39,
                        AttributeId = 5,
                        Value = "DOWNHILL",
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 40,
                        AttributeId = 5,
                        Value = "City / Градски",
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                    },
                     new ProductAttributeValue()
                    {
                        Id = 41,
                        AttributeId = 5,
                        Value = "Treking",
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 42,
                        AttributeId = 5,
                        Value = "Gravel Bike",
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                    },
                    new ProductAttributeValue()
                    {
                        Id = 43,
                        AttributeId = 5,
                        Value = "Шосе",
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                    },
                    
                ]);
        }
    }
}
