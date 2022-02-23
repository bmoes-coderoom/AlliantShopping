using AlliantShopping.Business.Interface;
using AlliantShopping.Data.Models;
using AlliantShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Business.Manager
{
    public class ProductStoreManager : IProductStoreManager
    {
        private IProductStoreRepository _productStoreRepository;
        public ProductStoreManager(IProductStoreRepository productStoreRepository)
        {
            _productStoreRepository = productStoreRepository;
        }

        public ProductStoreManager(string json)
        {
            _productStoreRepository = new ProductStoreRepository(json);
        }

        public List<Product> GetAllProductInventory()
        {
            return _productStoreRepository.Products;
        }

        public List<Discount> GetAllDiscounts()
        {
            return _productStoreRepository.Discounts;
        }

        public bool IsValidProduct(Product product)
        {
            return _productStoreRepository.Products.Contains(product);
        }
    }
}
