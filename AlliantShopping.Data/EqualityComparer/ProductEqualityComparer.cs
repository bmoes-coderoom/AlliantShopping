using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AlliantShopping.Data.EqualityComparer
{
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals([AllowNull] Product x, [AllowNull] Product y)
        {
            return x?.ProductCode == y?.ProductCode
                && x?.Price == y?.Price
                && x?.OnSale == y?.OnSale;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return ((obj?.ProductCode?.GetHashCode() * 17 ?? 0)
                + (obj?.Price.GetHashCode() * 17 ?? 0)
                + (obj?.OnSale.GetHashCode() * 17 ?? 0));
        }
    }
}
