﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Accountant accountant = new Accountant();

        public Inventory inventory = null;

        public VendingMachine(Dictionary<string, List<Item>> initialInventory)
        {
            inventory = new Inventory(initialInventory);
        }

        //-->We must check if item code is in stock. If so then run the DecrementItem function (return the item and delete it from list) & run the DispenseItem function
        public bool SelectItemByCode(string id)
        {
            bool success = false;
            if (string.IsNullOrEmpty(id)) return success;

            string itemIdUpper = id.ToUpper();
            //check each item in dicitonary

            if (inventory.ItemLocations.ContainsKey(itemIdUpper))
            {
                //RETURN THIS ITEM BACK TO THE MENU CLASS AND DO THE CW's BASED ON ITEM TYPE
                Item selectedItem = inventory.ItemDecrementInventory(itemIdUpper);

                DispenseItem(selectedItem, itemIdUpper);

                success = true;
            }


            return success;
        }
        
        //We'll call our Accountant here as well to adjust the balance after item is selected and decremented
        public void DispenseItem(Item item, string id)
        {
            string itemIdUpper = id.ToUpper();

            accountant.DecrementBalance(item.Price);
            Console.WriteLine($"{item.Name}, {item.Price:C2}, {accountant.Balance:C2}");

            //log the transaction to the log file in /bin via the static method Log on the Logger class
            Logger.Log(item.Name, itemIdUpper, item.Price, accountant.Balance);

            //THINK OF MOVING THE CW's HERE TO THE MENU CLASS
                //ACCESS THIS INFO BY RETURNING OUR ITEM BACK TO SELECTITEMBYCODE
            if (item.Type == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            if (item.Type == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            if (item.Type == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            if (item.Type == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }

        }
    }
}
