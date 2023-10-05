using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public Item(string name, decimal price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
        }
    }
}
