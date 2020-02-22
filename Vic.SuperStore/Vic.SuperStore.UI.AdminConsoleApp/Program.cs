using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Services;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.UI.AdminConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();

            bool canExit = false;

            do
            {
                Console.WriteLine("--------");
                Console.WriteLine("please type your command:");
                Console.WriteLine("example:");
                Console.WriteLine("add product {id} {name} {price} {count}");
                Console.WriteLine("get product {id}");
                Console.WriteLine("remove product {id} {count}");
                Console.WriteLine("get all products");
                Console.WriteLine("q to exit app.");
                Console.WriteLine("--------");

                var command = Console.ReadLine().ToLowerInvariant();
                var commandSplits = command.Split(' ');

                if (command.StartsWith("add product"))
                {
                    var id = int.Parse(commandSplits[2]);
                    var name = commandSplits[3];
                    var price = decimal.Parse(commandSplits[4]);
                    var count = int.Parse(commandSplits[5]);

                    var product = productService.AddProduct(id, name, price, count);
                    Console.WriteLine("Add product succeeded.");
                    Console.WriteLine(product);

                    continue;
                }

                if (command.StartsWith("get product"))
                {
                    var id = int.Parse(commandSplits[2]);
                    var product = productService.GetProductById(id);
                    Console.WriteLine(product);

                    continue;
                }

                if (command.StartsWith("remove product"))
                {
                    var id = int.Parse(commandSplits[2]);
                    var count = int.Parse(commandSplits[3]);
                    var product = productService.RemoveProductById(id, count);

                    if (product == null)
                    {
                        Console.WriteLine($"Product {id} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine(product);
                    }

                    continue;
                }

                if (command.StartsWith("get all products"))
                {
                    var products = productService.GetAllProducts();

                    foreach (var item in products)
                    {
                        Console.WriteLine(item);
                    }

                    continue;
                }

                if (command == "q")
                {
                    canExit = true;
                    continue;
                }

                Console.WriteLine("Wrong command, please try again.");
            } while (!canExit);

            Console.WriteLine("Bye.");
        }
    }
}
