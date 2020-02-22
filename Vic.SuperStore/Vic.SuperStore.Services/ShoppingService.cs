using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.Services
{
    public class ShoppingService
    {
        private readonly ProductService _productService = new ProductService();

        public void AddShoppingItem(
            ShoppingCart shoppingCart,
            int productId,
            int count = 1)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException();
            }

            var product = _productService.GetProductById(productId);

            if (product.Count < count)
            {
                throw new InvalidOperationException($"Product {product.Id} count is not enough.");
            }

            var shoppingItem = shoppingCart
                .ShoppingItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (shoppingItem == null)
            {
                shoppingItem = new ShoppingItem
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Count = count
                };

                shoppingCart.ShoppingItems.Add(shoppingItem);
            }
            else
            {
                shoppingItem.Count += count;
            }

            _productService.RemoveProductById(productId, count);
        }

        public void RemoveShoppingItem(
            ShoppingCart shoppingCart,
            int productId,
            int count = 1)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException();
            }

            var shoppingItem = shoppingCart
                .ShoppingItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (shoppingItem != null)
            {
                int countToAddBack = Math.Min(shoppingItem.Count, count);

                shoppingItem.Count -= count;

                if (shoppingItem.Count <= 0)
                {
                    shoppingCart.ShoppingItems.Remove(shoppingItem);
                }

                _productService.AddProduct(productId, countToAddBack);
            }
        }

        public List<ShoppingItem> CheckShoppingCart(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.ShoppingItems)
            {
                Console.WriteLine(item);
            }

            return shoppingCart.ShoppingItems;
        }

        public Receipt Checkout(ShoppingCart shoppingCart)
        {
            var result = new Receipt();

            foreach (var item in shoppingCart.ShoppingItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    result.ReceiptItems.Add(new ReceiptItem
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductPrice = item.ProductPrice
                    });
                }
            }

            result.TotalItems = result.ReceiptItems.Count;
            result.TotalPrice = result.ReceiptItems.Sum(x => x.ProductPrice);

            return result;
        }
    }
}
