using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]

    public class VMEmployeeTests
    {
        [TestMethod]
        [DataRow(16)]
        public void VMEmployee_HappyPath(int count)
        {

            //arragne
            VMEmployee sut = new VMEmployee();
            Dictionary<string, List<Item>> actual = sut.StockVM();
            int expected = actual.Count;

            //act
            //assert
            CollectionAssert.AllItemsAreNotNull(actual);
            CollectionAssert.AllItemsAreUnique(actual);
            Assert.AreEqual(count, expected);

        }
    }
}
