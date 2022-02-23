using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Data.Models
{
    public class Discount
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
