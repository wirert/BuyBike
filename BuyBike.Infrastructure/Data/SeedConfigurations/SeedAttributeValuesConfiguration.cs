namespace BuyBike.Infrastructure.Data.SeedConfigurations
{
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SeedAttributeValuesConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasData(
                [
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        Value = "29",                        
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        Value = "29",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        Value = "29",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        Value = "28",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        Value = "28",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        Value = "28",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        Value = "28",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                        Value = "12",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 1,
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                        Value = "12",
                    },

                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        Value = "carbon",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        Value = "carbon",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                        Value = "alloy",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 2,
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                        Value = "steel",
                    },

                     new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        Value = "v-brake",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        Value = "disc",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                        Value = "v-brake",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 3,
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                        Value = "v-brake",
                    },

                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        Value = "Пълно окачване",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        Value = "Пълно окачване",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        Value = "Пълно окачване",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        Value = "Пълно окачване",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        Value = "Твърда вилка",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        Value = "Амортисьорна вилка",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        Value = "Пълно окачване",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("c8a565f6-eb03-44b1-bed9-68dcdbff914e"),
                        Value = "Амортисьорна вилка",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 4,
                        ProductId = Guid.Parse("b46a5b25-1e35-4006-b862-71b8b0f7e816"),
                        Value = "Твърда вилка",
                    },

                     new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("78804049-030f-4373-be3c-dfb4df261846"),
                        Value = "Крос кънтри / XC",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("751f85bf-9f3a-443d-a66f-1ad719e50b4e"),
                        Value = "Крос кънтри / XC",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("6f88c752-2b55-4380-8287-0e85a569abd5"),
                        Value = "All Mountain / Trail",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("c77e1e5a-86eb-4356-86c1-c6868494df85"),
                        Value = "Treking",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("4f195fb8-03d7-42c0-bbe6-3edc190ce51e"),
                        Value = "Градски / City",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("dd32437b-1dfb-4a4d-bca4-43b1294a925e"),
                        Value = "Шосе",
                    },
                    new ProductAttributeValue()
                    {
                        AttributeId = 5,
                        ProductId = Guid.Parse("0c3f8754-5dce-4fd5-bdb6-79fc79b07e75"),
                        Value = "Gravel",
                    },
                ]);
        }
    }
}
