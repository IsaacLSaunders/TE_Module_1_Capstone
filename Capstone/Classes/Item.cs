using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Item
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string type, string name, decimal price)
        {
            Type = type;
            Name = name;
            Price = price;
        }
    }
}
