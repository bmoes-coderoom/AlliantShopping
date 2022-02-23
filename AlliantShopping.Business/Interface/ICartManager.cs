using AlliantShopping.Data;
using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Business.Interface
{
    public interface ICartManager
    {
        void AddToCart(Product product);

        decimal GetTotalWithDiscounts();
        Cart GetCart();
    }
}
