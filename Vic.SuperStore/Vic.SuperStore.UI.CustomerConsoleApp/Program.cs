using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Services;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.UI.CustomerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingService shoppingService = new ShoppingService();
            ProductService productService = new ProductService();
            ShoppingCart cart = new ShoppingCart();
            Printer printer = new Printer();

            bool canExit = false;

            do
            {
                Console.WriteLine("--------");
                Console.WriteLine("please type your command:");
                Console.WriteLine("example:");
                Console.WriteLine("get all products");
                Console.WriteLine("add product {id}");
                Console.WriteLine("remove product {id}");
                Console.WriteLine("check shoppingcart");
                Console.WriteLine("checkout");
                Console.WriteLine("q to exit app.");
                Console.WriteLine("--------");

                var command = Console.ReadLine().ToLowerInvariant();
                var commandSplits = command.Split(' ');

                if (command.StartsWith("get all products"))
                {
                    var products = productService.GetAllProducts();

                    foreach (var item in products)
                    {
                        Console.WriteLine(item);
                    }

                    continue;
                }

                if (command.StartsWith("add product"))
                {
                    var id = int.Parse(commandSplits[2]);

                    shoppingService.AddShoppingItem(cart, id);
                    shoppingService.CheckShoppingCart(cart);

                    continue;
                }

                if (command.StartsWith("remove product"))
                {
                    var id = int.Parse(commandSplits[2]);

                    shoppingService.RemoveShoppingItem(cart, id);
                    shoppingService.CheckShoppingCart(cart);

                    continue;
                }

                if (command.StartsWith("check shoppingcart"))
                {
                    shoppingService.CheckShoppingCart(cart);

                    continue;
                }

                if (command.StartsWith("checkout"))
                {
                    var receipt = shoppingService.Checkout(cart);
                    printer.PrintReceipt(receipt);

                    canExit = true;
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
            Console.ReadLine();
        }
    }
}
