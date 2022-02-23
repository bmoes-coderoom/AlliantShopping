using AlliantShopping.Data.Models;
using AlliantShopping.Data.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlliantShopping.Data.Repository
{
    public class ProductStoreRepository : IProductStoreRepository
    {
        private ProductStore _productStore;
        /// <summary>
        /// Class is initialized with Json Obect to populate the store
        /// </summary>
        /// <param name="json"></param>
        public ProductStoreRepository(string json)
        {
            _productStore = JsonSerializer.Deserialize<ProductStore>(json);
        }
        public List<Product> Products
        {
            get
            {
                return _productStore.Products;
            }

        }

        public List<Discount> Discounts
        {
            get
            {
                return _productStore.Discounts;
            }
        }
    }
}
