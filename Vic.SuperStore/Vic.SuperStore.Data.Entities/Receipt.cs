using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperStore.Data.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }
    }
}
