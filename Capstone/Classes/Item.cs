using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    //THIS IS MAYBE AN ABSTRACT CLASS
    //WE CAN ADD THE SOUND THAT IT MAKES HERE
    //OVERRIDE THE TOSTRING METHOD TO PRINT THE MESSAGE BY TYPE
    public class Item
    {
        //ADD A MESSAGE PROPERTY
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
