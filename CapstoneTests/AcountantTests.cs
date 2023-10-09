using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class AcountantTests
    {

        [TestMethod]
        [DataRow(4, 4.00)]
        [DataRow(5, 5.00)]
        [DataRow(5000, 5000.00)]
        [DataRow(5000, 5000.00)]
        [DataRow(1/2, 0.00)]
        [DataRow(int.MaxValue, int.MaxValue)]
        public void AccountantIncrementBalance_HappyPath(int price, double expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            decimal expectedAsDecimal = Convert.ToDecimal(expected);

            //act
            sut.IncrementBalance(price);

            //assert
            Assert.AreEqual(sut.Balance, expectedAsDecimal);
        }

        [TestMethod]
        [DataRow(int.MinValue, 0.00)]
        [DataRow(-3, 0.00)]
        [DataRow(-6, 0.00)]
        [DataRow(-1000, 0.00)]
        public void AccountantIncrementBalance_NegativeNumberInput(int price, double expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            decimal expectedAsDecimal = Convert.ToDecimal(expected);

            //act
            sut.IncrementBalance(price);

            //assert
            Assert.AreEqual(sut.Balance, expectedAsDecimal);
        }
        

        [TestMethod]
        [DataRow(4, (double)(int.MaxValue - 4))]
        [DataRow(5, (double)(int.MaxValue - 5))]
        [DataRow(5000, (double)(int.MaxValue - 5000))]
        [DataRow(1/2, (double)(int.MaxValue))]
        [DataRow(int.MaxValue, 0)]
        public void AccountantDecrementBalance_HappyPath(int price, double expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            sut.IncrementBalance(Convert.ToDecimal(int.MaxValue));
            decimal expectedAsDecimal = Convert.ToDecimal(expected);

            //act
            sut.DecrementBalance(price);

            //assert
            Assert.AreEqual(sut.Balance, expectedAsDecimal);
        }
        
        [TestMethod]
        [DataRow(int.MinValue, 0)]
        [DataRow(-3, 0)]
        [DataRow(-6, 0)]
        [DataRow(-1000, 0)]
        public void AccountantDecrementBalance_NegativeNumberInput(int price, double expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            sut.IncrementBalance(Convert.ToDecimal(int.MaxValue));
            decimal expectedAsDecimal = Convert.ToDecimal(expected);

            //act
            sut.DecrementBalance(price);

            //assert
            Assert.AreEqual(sut.Balance, expectedAsDecimal);
        }

        [TestMethod]
        [DataRow(4, true)]
        [DataRow(5, true)]
        [DataRow(5000, true)]
        [DataRow(500000, true)]
        [DataRow(1 / 2, true)]
        public void AccountantGiveChange_HappyPath(int price, bool expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            sut.IncrementBalance(Convert.ToDecimal(price));

            //act
            bool actual = sut.DispenseChange();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(500000, true)]
        [DataRow(500000000, true)]
        [DataRow(int.MaxValue, true)]
        public void AccountantGiveChange_OversizedBalanceConvertToPennies(int price, bool expected)
        {
            //arrange 
            Accountant sut = new Accountant();
            sut.IncrementBalance(Convert.ToDecimal(price));

            //act
            bool actual = sut.DispenseChange();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
