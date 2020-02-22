using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.Data.Repositories
{
    public interface IProductRepositories
    {
        void AddOrUpdateProdcut(int id, string name, decimal price, int count);
        void RemoveProduct(int id, int count);
        Product GetProductById(int id);
        List<Product> GetProducts();
    }
}
