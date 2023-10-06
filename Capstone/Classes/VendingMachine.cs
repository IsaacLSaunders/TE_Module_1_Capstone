using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Accountant accountant = new Accountant();

        public Inventory inventory;

        public VendingMachine(Dictionary<string, List<Item>> initialInventory)
        {
            inventory = new Inventory(initialInventory);
        }

        //-->We must check if item code is in stock. If so then run the DecrementItem function (return the item and delete it from list) & run the DispenseItem function
        public bool SelectItemByCode(string id)
        {
            bool success = false;
            //check each item in dicitonary
            if (inventory.ItemLocations.ContainsKey(id))
            {
                Item selectedItem = inventory.ItemDecrementInventory(id);

                DispenseItem(selectedItem, id);

                success = true;
            }


            return success;
        }
        
        //We'll call our Accountant here as well to adjust the balance after item is selected and decremented
        public void DispenseItem(Item item, string id)
        {
            Console.WriteLine($"{item.Name}, {item.Price}, {accountant.Balance}");
            accountant.DecrementBalance(item.Price);

            //log the transaction to the log file in /bin via the static method Log on the Logger class
            Logger.Log(item.Name, id, item.Price, accountant.Balance);

            if (item.Type == "chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            if (item.Type == "candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            if (item.Type == "drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            if (item.Type == "gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }

        }
    }
}
