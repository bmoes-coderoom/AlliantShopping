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
    }
}
