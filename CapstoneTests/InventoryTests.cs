using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]

    public class InventoryTests
    {

        [TestMethod]
        public void ItemDecrementInventoryDecrement_HappyPath() //testing that our items are removed from stock appropriately
        {

            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());
            VendingMachine vendingMachineTest = new VendingMachine(employee.StockVM());

            //Act 
            vendingMachine.inventory.ItemLocations["B2"].RemoveAt(0);
            vendingMachineTest.inventory.ItemDecrementInventory("B2");
            //in one dictionary, remove an item in the list of items manually using the List.Remove method
            //in the other dictionary remove an item using our decrementInventory method, passing in the id
            //once this is completed

            //Assert
            //compare the values in the two dictionaries
            //CollectionAssert.AreEquivalent? not sure
            //assert.areEqual count of each list at the id in the dictionary?
            Assert.AreEqual(vendingMachine.inventory.ItemLocations["B2"].Count, vendingMachineTest.inventory.ItemLocations["B2"].Count);

        }


        [TestMethod]
       
        [DataRow("2")]
        [DataRow("")]
        [DataRow("J1")]
        [DataRow("v3")]
        [DataRow("63")]
        public void ItemDecrementInventory_InvalidId(string id) //testing that our items are removed from stock appropriately 
        { //WE DO NOT GET TO THE ITEMDECREMENTINVENTORY METHOD IF WE DO NOT HAVE VALID INPUT FOR SELECTITEMBYCODEMETHOD. THIS IS TESTED BY SELECTITEMBYCODE TESTS

            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachineTest = new VendingMachine(employee.StockVM());

            //Act 
            //Assert
            //compare the values in the two dictionaries
            //CollectionAssert.AreEquivalent? not sure
            //assert.areEqual count of each list at the id in the dictionary?
            Assert.IsNull(vendingMachineTest.inventory.ItemDecrementInventory(id));

        }
    }
}
