using AlliantShopping.Business.Interface;
using AlliantShopping.Data;
using AlliantShopping.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlliantShopping.Business.Manager
{
    public class CartManager : ICartManager
    {
        private Cart _cart;
        private IProductStoreManager _productStoreManager;
        public CartManager(Cart cart, IProductStoreManager productStoreManager)
        {
            _cart = cart;
            _productStoreManager = productStoreManager;
        }

        public CartManager(IProductStoreManager productStoreManager)
        {
            _productStoreManager = productStoreManager;
            _cart = new Cart();
        }

        public void AddToCart(Product product)
        {
            if(product != null && product.ProductCode != null)
            {
                if (_productStoreManager.IsValidProduct(product))
                {
                    if (!_cart.ItemDict.ContainsKey(product))
                    {
                        _cart.ItemDict.Add(product, 1);
                    }
                    else
                    {
                        var count = _cart.ItemDict.GetValueOrDefault(product);
                        var updatedQuantity = count + 1;
                        _cart.ItemDict[product] = updatedQuantity;
                    }
                }

            }
        }

        public Cart GetCart()
        {
            return _cart;
        }

        public decimal GetTotalWithDiscounts()
        {
            return CalculateTotalPriceForA() + CalculateTotalPriceForB() + CalculateTotalPriceForC() + CalculateTotalPriceForD();
        }

        private decimal CalculateTotalPriceForB()
        {
            var productB = _productStoreManager.GetAllProductInventory()
                .FirstOrDefault(x => x.ProductCode == "B");
            decimal finalCost = 0.00M;
            // See how many A products are in cart
            _cart.ItemDict.TryGetValue(productB, out int count);
            finalCost = count * productB.Price;
            return finalCost;
        }

        private decimal CalculateTotalPriceForD()
        {
            var productD = _productStoreManager.GetAllProductInventory()
                .FirstOrDefault(x => x.ProductCode == "D");
            decimal finalCost = 0.00M;
            // See how many A products are in cart
            _cart.ItemDict.TryGetValue(productD, out int count);
            finalCost = count * productD.Price;
            return finalCost;
        }

        private decimal CalculateTotalPriceForA()
        {
            return CalculateTotalPriceForOnSaleItem("A");
        }

        private decimal CalculateTotalPriceForC()
        {
            return CalculateTotalPriceForOnSaleItem("C");
        }

        private decimal CalculateTotalPriceForOnSaleItem(string productCode)
        {
            var discount = _productStoreManager.GetAllDiscounts()
    .FirstOrDefault(x => x.ProductCode == productCode);
            var product = _productStoreManager.GetAllProductInventory()
                .FirstOrDefault(x => x.ProductCode == productCode && x.OnSale);
            decimal finalCost = 0.00M;
            // See how many sale products are in cart
            _cart.ItemDict.TryGetValue(product, out int count);
            if (count > 0)
            {
                if (product.OnSale)
                {
                    if (count >= discount.Quantity)
                    {
                        // 4 / 4 == 1
                        // 7 / 4 = 1
                        var NumOfDiscounts = count / discount.Quantity;

                        var discountPrice = NumOfDiscounts * discount.DiscountPrice;
                        // 4- 4 = 0
                        // 7 - 4 = 3
                        var regularPriceItems = count - discount.Quantity;

                        var regSalePrice = regularPriceItems * product.Price;

                        finalCost = discountPrice + regSalePrice;
                    }
                    else
                    {
                        finalCost = count * product.Price;
                    }
                }
                else
                {
                    finalCost = count * product.Price;
                }
            }

            return finalCost;
        }
    }
}
