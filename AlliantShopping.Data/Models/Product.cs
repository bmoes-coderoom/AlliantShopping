using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Data.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
    }
}
