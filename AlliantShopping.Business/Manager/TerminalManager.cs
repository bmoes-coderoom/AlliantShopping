using AlliantShopping.Business.Interface;
using AlliantShopping.Data;
using AlliantShopping.Data.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlliantShopping.Business.Manager
{
    public class TerminalManager : ITerminal
    {
        private ICartManager _cartManager;
        private IProductStoreManager _productStoreManager;
        public TerminalManager(ICartManager cartManager
            ,IProductStoreManager productStoreManager)
        {
            _cartManager = cartManager;
            _productStoreManager = productStoreManager;
        }

        public TerminalManager(IProductStoreManager productStoreManager)
        {
            _productStoreManager = productStoreManager;
            _cartManager = new CartManager(_productStoreManager);
        }

        public void Scan(string item)
        {
            var product = _productStoreManager
                .GetAllProductInventory()
                .FirstOrDefault(x => x.ProductCode == item);
            _cartManager.AddToCart(product);
        }

        public Cart GetCurrentCart()
        {
            return _cartManager.GetCart();
        }

        public decimal Total()
        {
            return _cartManager.GetTotalWithDiscounts();
        }
    }
}
