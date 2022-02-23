using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Business.Interface
{
    public interface IProductStoreManager
    {
        List<Product> GetAllProductInventory();
        List<Discount> GetAllDiscounts();
        bool IsValidProduct(Product product);
    }
}
