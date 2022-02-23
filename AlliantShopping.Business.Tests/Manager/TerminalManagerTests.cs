using AlliantShopping.Business.Interface;
using AlliantShopping.Business.Manager;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlliantShopping.Business.Tests.Manager
{
    public class TerminalManagerTests
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
        public void Scan_Should_Add_Valid_Item_To_Cart()
        {
            // Arrange
            var productStoreManager = new ProductStoreManager(json);

            var terminal = new TerminalManager(productStoreManager);

            // Act
            terminal.Scan("A");

            // Assert
            var cart = terminal.GetCurrentCart();

            cart.ItemDict.Should().Contain(x => x.Key.ProductCode == "A");
        }

        [Fact]
        public void Scan_Should_Not_Add_Invalid_Item_To_Cart()
        {
            // Arrange
            var productStoreManager = new ProductStoreManager(json);

            var terminal = new TerminalManager(productStoreManager);

            // Act
            terminal.Scan("F");

            // Assert
            var cart = terminal.GetCurrentCart();

            cart.ItemDict.Should().NotContain(x => x.Key.ProductCode == "F");
        }

        [Fact]
        public void Total_Should_Return_Total()
        {
            // Arrange
            var mockCartManager = new Mock<ICartManager>();
            mockCartManager.Setup(x => x.GetTotalWithDiscounts())
                .Returns(100.25M);

            var terminal = new TerminalManager(mockCartManager.Object, null);

            // Act
            var result = terminal.Total();

            // Assert
            result.Should().Be(100.25M);
        }
    }
}
