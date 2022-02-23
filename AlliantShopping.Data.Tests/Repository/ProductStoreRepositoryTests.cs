using AlliantShopping.Data.Repository;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlliantShopping.Data.Tests.Repository
{
    public class ProductStoreRepositoryTests
    {
        string json = @"{
  ""Products"": [
    {
      ""ProductCode"": ""A"",
      ""Price"": 2.00,
      ""OnSale"": true
    },
    {
      ""ProductCode"": ""B"",
      ""Price"": 12.00,
      ""OnSale"": false
    },
    {
      ""ProductCode"": ""C"",
      ""Price"": 1.25,
      ""OnSale"": true
    },
    {
      ""ProductCode"": ""D"",
      ""Price"": 0.15,
      ""OnSale"": false
    }
  ],
  ""Discounts"": [
    {
      ""ProductCode"": ""A"",
      ""Quantity"": 4,
      ""DiscountPrice"": 7.00
    },
    {
      ""ProductCode"": ""C"",
      ""Quantity"": 6,
      ""DiscountPrice"": 6.00
    }
  ]
}
";
        [Fact]
        public void Products_Should_Return_SameNumberOfProducts_From_ProductStore()
        {
            // Arrange
            var productStoreRepo = new ProductStoreRepository(json);

            // Assert
            productStoreRepo.Products.Should().HaveCount(4);

        }

        [Fact]
        public void Discounts_Should_Return_SameNumberOfDiscounts_From_ProductStore()
        {
            // Arrange
            var productStoreRepo = new ProductStoreRepository(json);

            // Assert
            productStoreRepo.Discounts.Should().HaveCount(2);

        }
    }
}
