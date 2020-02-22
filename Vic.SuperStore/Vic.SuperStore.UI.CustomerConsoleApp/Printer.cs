using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SuperStore.Data.Entities;

namespace Vic.SuperStore.UI.CustomerConsoleApp
{
    public class Printer
    {
        public void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine("========");
            Console.WriteLine("Receipt");
            Console.WriteLine($"Receipt Id {receipt.Id}");
            Console.WriteLine("--------");
            foreach (var item in receipt.ReceiptItems)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------");
            Console.WriteLine($"Total Items: {receipt.TotalItems}");
            Console.WriteLine($"Total Price: {receipt.TotalPrice}");
            Console.WriteLine();
            Console.WriteLine("Thank you.");
            Console.WriteLine("========");
        }
    }
}
