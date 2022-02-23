using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AlliantShopping.Data.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product : IEquatable<Product>
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }

        public bool Equals([AllowNull] Product other)
        {
            if (other == null) return false;
            return (this.ProductCode.Equals(other.ProductCode));
        }
    }
}
