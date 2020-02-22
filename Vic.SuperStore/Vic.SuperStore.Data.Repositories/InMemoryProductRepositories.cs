using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.Data.Repositories
{
    public class InMemoryProductRepositories : IProductRepositories
    {
        private readonly List<Product> _products = new List<Product>();

        public void AddOrUpdateProdcut
            (int id,
            string name,
            decimal price,
            int count)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price must larger then 0.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.");
            }

            if (count <= 0)
            {
                throw new ArgumentException("Count must larger then 0.");
            }

            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                product = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Count = count
                };

                _products.Add(product);
            }
            else
            {
                product.Name = name;
                product.Price = price;
                product.Count += count;
            }
        }

        public Product GetProductById(int id)
        {
            var result = _products.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void RemoveProduct(int id, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must larger then 0.");
            }

            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                product.Count -= count;

                if (product.Count <= 0)
                {
                    _products.Remove(product);
                }
            }
        }
    }
}
