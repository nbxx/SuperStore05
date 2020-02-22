using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperStore.Data.Entities
{
    public class ReceiptItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public override string ToString()
        {
            return $"ReceiptItem Product Id = {ProductId}, Name = {ProductName}, Pirce = {ProductPrice}";
        }
    }
}
