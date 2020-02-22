using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;
using Vic.SuperStore.Data.Repositories;

namespace Vic.SuperStore.Services
{
    public class ProductService
    {
        private IProductRepositories _productRepositories = new JsonProductRepositories();

        public Product AddProduct(
            int id,
            string name,
            decimal price,
            int count = 1)
        {
            _productRepositories.AddOrUpdateProdcut(id, name, price, count);
            return _productRepositories.GetProductById(id);
        }

        public Product AddProduct(
            int id,
            int count = 1)
        {
            var product = _productRepositories.GetProductById(id);
            _productRepositories.AddOrUpdateProdcut(id, product.Name, product.Price, count);
            return _productRepositories.GetProductById(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepositories.GetProductById(id);
        }

        public Product RemoveProductById(int id, int count = 1)
        {
            _productRepositories.RemoveProduct(id, count);
            return _productRepositories.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepositories.GetProducts();
        }

    }
}
