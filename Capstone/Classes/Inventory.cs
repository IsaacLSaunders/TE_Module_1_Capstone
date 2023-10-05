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
            foreach(KeyValuePair<string,List<Item>> keyValuePair in ItemLocations)
            {

                Console.WriteLine($"{keyValuePair.Key}|{keyValuePair.Value[0].Name}|{keyValuePair.Value[0].Price}|{keyValuePair.Value[0].Type}|{keyValuePair.Value.Count}");

            }
        }

        public Item ItemDecrementInventory(string id)
        {
            Item removedItem = ItemLocations[id][ItemLocations[id].Count-1];
            ItemLocations[id].RemoveAt(ItemLocations[id].Count - 1);

            return removedItem;
        }

    }


}
