using AlliantShopping.Business.Interface;
using AlliantShopping.Business.Manager;
using AlliantShopping.Data;
using AlliantShopping.Data.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlliantShopping.Business.Tests.Manager
{
    public class CartManagerTests
    {
        [Fact]
        public void AddToCart_Should_Add_New_Product_To_Cart()
        {
            // Arrange
            var cart = new Cart();
            var product = new Product
            {
                ProductCode = "A"
            };
            var productStoreManagerMock = new Mock<IProductStoreManager>();

            productStoreManagerMock
                .Setup(x => x.IsValidProduct(product))
                .Returns(true);

            var cartManager = new CartManager(cart, productStoreManagerMock.Object);

            // Act
            cartManager.AddToCart(product);

            // Assert
            cart.ItemDict.Should().Contain(product, 1);
            cart.ItemDict.Count.Should().Be(1);
        }

        [Fact]
        public void AddToCart_Should_Increment_ProductCount_When_Existing_Product_Is_Added_To_Cart()
        {
            // Arrange
            var cart = new Cart();
            var firstProduct = new Product
            {
                ProductCode = "A"
            };
            cart.ItemDict.Add(firstProduct, 1);
            var secondProduct = new Product
            {
                ProductCode = "A"
            };
            var productStoreManagerMock = new Mock<IProductStoreManager>();

            productStoreManagerMock
                .Setup(x => x.IsValidProduct(secondProduct))
                .Returns(true);
            var cartManager = new CartManager(cart, productStoreManagerMock.Object);

            // Act
            cartManager.AddToCart(secondProduct);

            // Assert
            cart.ItemDict.Should().Contain(secondProduct, 2);
            cart.ItemDict.Count.Should().Be(1);
        }

        [Fact]
        public void AddToCart_Should_Not_Add_Product_To_Cart_That_DNE_In_Inventory()
        {
            // Arrange
            var cart = new Cart();
            var product = new Product
            {
                ProductCode = "E"
            };
            var productStoreManagerMock = new Mock<IProductStoreManager>();

            productStoreManagerMock
                .Setup(x => x.IsValidProduct(product))
                .Returns(false);
            var cartManager = new CartManager(cart, productStoreManagerMock.Object);

            // Act
            cartManager.AddToCart(product);

            // Assert
            cart.ItemDict.Should().NotContain(product, 1);
            cart.ItemDict.Count.Should().Be(0);
        }

        [Fact]
        public void GetTotalWithDiscounts_Should_Calculate_Total_In_Cart()
        {
            // Arrange
            // We can use json string and real ProductStoreManager object
            // so that we can cut down on setup
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
            var productStoreManager = new ProductStoreManager(json);
            var cart = new Cart();
            foreach (var product in productStoreManager.GetAllProductInventory())
            {
                if(product.ProductCode == "A")
                {
                    cart.ItemDict.Add(product, 4);
                }
                else if(product.ProductCode == "C")
                {
                    cart.ItemDict.Add(product, 6);
                }
                else
                {
                    cart.ItemDict.Add(product, 1);
                }

            }



            var cartManager = new CartManager(cart, productStoreManager);

            // Act
            var result = cartManager.GetTotalWithDiscounts();

            // Assert
            result.Should().Be(25.15M);
        }
    }
}
