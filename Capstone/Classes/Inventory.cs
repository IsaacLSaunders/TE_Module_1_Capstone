using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        public Dictionary<string, List<Item>> ItemLocations = new Dictionary<string, List<Item>>(); //handle invalid item codes at user input 

        

        public Item ItemDecrementInventory(string id)
        {
            Item removedItem = ItemLocations[id][ItemLocations[id].Count-1];
            ItemLocations[id].RemoveAt(ItemLocations[id].Count - 1);

            return removedItem;
        }

    }


}
