using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Accountant accountant = new Accountant();

        public Inventory inventory = new Inventory();


        //-->We must check if item code is in stock. If so then run the DecrementItem function (return the item and delete it from list) & run the DispenseItem function
        public bool SelectItemByCode(string id)
        {
            bool success = false;
            //check each item in dicitonary
            if (inventory.ItemLocations.ContainsKey(id))
            {
                Item selectedItem = inventory.ItemDecrementInventory(id);

                DispenseItem(selectedItem);

                success = true;
            }


            return success;
        }
        public void DispenseItem(Item item)
        {
            
        }
    }
}
