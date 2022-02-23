using AlliantShopping.Business.Manager;
using AlliantShopping.Data.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlliantShopping.Business.Tests.Manager
{
    public class ProductStoreManagerTests
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
        public void IsValidProduct_Should_Return_True_Given_Product_Exists_In_Inventory()
        {
            // Arrange
            var productStoreManager = new ProductStoreManager(json);

            var product = productStoreManager.GetAllProductInventory().FirstOrDefault(x => x.ProductCode == "A");

            // Act
            var result = productStoreManager.IsValidProduct(product);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidProduct_Should_Return_False_Given_Product_DNE_In_Inventory()
        {
            // Arrange
            var productStoreManager = new ProductStoreManager(json);

            Product product = null;

            // Act
            var result = productStoreManager.IsValidProduct(product);

            // Assert
            result.Should().BeFalse();
        }
    }
}
