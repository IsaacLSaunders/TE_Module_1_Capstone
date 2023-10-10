using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapstoneTests
{
    [TestClass]

    public class VendingMachineTests
    {
        [TestMethod]
        [DataRow("a2", true)]
        [DataRow("C1", true)]
        [DataRow("D4", true)]
        [DataRow("b3", true)]
        [DataRow("A2", true)]
        public void SelectItemByCode_HappyPath(string input, bool expected)
        {
            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());
            VendingMachine sut = new VendingMachine(employee.StockVM());


            //Act
            bool actual = sut.SelectItemByCode(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [DataRow("z2", false)]
        [DataRow("E1", false)]
        [DataRow("K71", false)]
        [DataRow("H", false)]
        [DataRow("0", false)]

        public void SelectItemByCode_InvalidId(string input, bool expected)
        {
            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());
            VendingMachine sut = new VendingMachine(employee.StockVM());

            //Act
            bool actual = sut.SelectItemByCode(input);

            //Assert
            Assert.AreEqual(expected, actual, "That is not a valid input.");
        }


        [TestMethod]

        public void SelectItemByCode_NullOrEmptyId()
        {
            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());
            VendingMachine sut = new VendingMachine(employee.StockVM());

            string input = null;
            bool expected = false;

            string input1 = "";
            bool expected1 = false;

            //Act
            bool actual = sut.SelectItemByCode(input);
            bool actual1 = sut.SelectItemByCode(input1);

            //Assert
            Assert.AreEqual(expected, actual, "That is not a valid input.");
            Assert.AreEqual(expected1, actual1, "That is not a valid input.");
        }


        [TestMethod]
        [DataRow("D3", true)]
        [DataRow("D3", true)]
        [DataRow("D3", true)]
        [DataRow("d3", true)]
        [DataRow("d3", true)]
        [DataRow("d3", true)] //Set to false as no 6th item (sold out)?

        public void SelectItemByCode_SoldOut(string input, bool expected) //This will break!
        {
            //Arrange
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());
            VendingMachine sut = new VendingMachine(employee.StockVM());


            //Act

            bool actual = sut.SelectItemByCode(input);


            //Assert
            Assert.AreEqual(expected, actual, "This item is out of stock.");


        }
    }
}

