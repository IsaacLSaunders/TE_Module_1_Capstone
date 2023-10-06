using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{     //StockVM() will return Dictionary<string, List(Items)>
    public class VMEmployee
    {
        public Dictionary<string, List<Item>> StockVM()
        {
            Dictionary<string, List<Item>> returnDict = new Dictionary<string, List<Item>>();

            string directory = Environment.CurrentDirectory;
            string inputFile = "vendingmachine.csv";

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(directory, inputFile)))
                {
                    string id = "";
                    List<Item> listOfItems = new List<Item>();

                    string name = "";
                    decimal price = 0.00M;
                    string type = "";

                    string line = sr.ReadLine();
                    string[] splitLine = line.Split("|");

                    id = splitLine[0];
                    name = splitLine[1];
                    try
                    {
                        price = decimal.Parse(splitLine[2]);
                    }
                    catch (Exception)
                    {
                    }
                    type = splitLine[3];

                    for (int i=0; i<5; i++)
                    {
                        Item newItem = new Item(name, price, type);
                        listOfItems.Add(newItem);
                    }
                    returnDict.Add(id,listOfItems);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return returnDict;

        }
    }
}
