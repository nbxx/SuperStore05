using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Vic.SuperStore.Data.Repositories
{
    public class JsonProductRepositories : IProductRepositories
    {
        private const string ProductJsonFile = "ProductData.json";

        public void AddOrUpdateProdcut(int id, string name, decimal price, int count)
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

            var products = GetProductsFromJson();

            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                product = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Count = count
                };

                products.Add(product);
            }
            else
            {
                product.Name = name;
                product.Price = price;
                product.Count += count;
            }

            SaveToJson(products);
        }

        public Product GetProductById(int id)
        {
            var products = GetProductsFromJson();
            var result = products.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Product> GetProducts()
        {
            var products = GetProductsFromJson();
            return products;
        }

        public void RemoveProduct(int id, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must larger then 0.");
            }

            var products = GetProductsFromJson();

            var product = products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                product.Count -= count;

                if (product.Count <= 0)
                {
                    products.Remove(product);
                }
            }

            SaveToJson(products);
        }

        private List<Product> GetProductsFromJson()
        {
            var products = new List<Product>();

            try
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductJsonFile));
            }
            catch
            {
            }

            return products;
        }

        private void SaveToJson(List<Product> products)
        {
            File.WriteAllText(ProductJsonFile, JsonConvert.SerializeObject(products));
        }
    }
}
