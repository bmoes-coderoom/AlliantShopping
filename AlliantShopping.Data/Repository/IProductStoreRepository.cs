using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Data.Repository
{
    public interface IProductStoreRepository
    {
        List<Product> Products { get; }

        List<Discount> Discounts { get; }

    }
}
