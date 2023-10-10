using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        public Dictionary<string, List<Item>> ItemLocations; //handle invalid item codes at user input 

        //this data comes from the VMEmployee class ==> VMEmployee is our data access class
        public Inventory(Dictionary<string, List<Item>> inventory)
        {
            ItemLocations = inventory;
        }


        public void DisplayInventory()
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, List<Item>> keyValuePair in ItemLocations)
            {
                try
                {
                    Console.WriteLine($"{keyValuePair.Key}|{keyValuePair.Value[0].Name}|{keyValuePair.Value[0].Price}|{keyValuePair.Value[0].Type}|{keyValuePair.Value.Count}");
                }
                catch
                {
                    Console.WriteLine("This item is out of stock.");
                }
            }
        }

        public Item ItemDecrementInventory(string id)
        {
            string itemIdUpper = id.ToUpper();

            Item removedItem = ItemLocations[itemIdUpper][ItemLocations[itemIdUpper].Count - 1];
            ItemLocations[itemIdUpper].RemoveAt(ItemLocations[itemIdUpper].Count - 1);

            return removedItem;
        }

    }


}
