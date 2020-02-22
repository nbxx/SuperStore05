﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SuperStore.Data.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
    }
}
