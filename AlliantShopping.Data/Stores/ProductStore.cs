using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Data.Stores
{
    /// <summary>
    /// This Class is the root object for the productstore.json file
    /// </summary>
    public class ProductStore
    {
        public List<Product> Products { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
