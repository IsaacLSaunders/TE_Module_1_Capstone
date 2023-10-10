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

            //THIS IS CONFUSING, is there a better way...? Who knows... maybe Mr. Anderson

            string itemIdUpper = null;

            if (!string.IsNullOrEmpty(id))
            {
                itemIdUpper = id.ToUpper();

                if (!ItemLocations.ContainsKey(itemIdUpper))
                {
                    return null;
                }
            }
            else if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            itemIdUpper = id.ToUpper();

            Item removedItem = ItemLocations[itemIdUpper][ItemLocations[itemIdUpper].Count - 1];
            ItemLocations[itemIdUpper].RemoveAt(ItemLocations[itemIdUpper].Count - 1);

            return removedItem;
        }

    }


}
