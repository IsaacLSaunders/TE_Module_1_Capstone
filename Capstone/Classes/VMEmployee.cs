using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{     //StockVM() will return Dictionary<string, List(Items)>
    public class VMEmployee
    {


        private const int NumberOfItemsInRow = 5;

        public Dictionary<string, List<Item>> StockVM()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            Dictionary<string, List<Item>> returnDictionary = new Dictionary<string, List<Item>>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string id = "";
                        List<Item> returnList = new List<Item>();

                        //read a line from the file
                        string line = sr.ReadLine();
                        //split line on pipes into a string called itemString(id,name,type,price)
                        decimal parsedVariable = 0.00M;
                        try
                        {
                            string[] itemString = line.Split("|");

                            //go through my array of itemStrings and pull string before the first |

                            //set this aside as my itemID
                            id = itemString[0];

                            parsedVariable = decimal.Parse(itemString[2]);

                            for (int i = 0; i < NumberOfItemsInRow; i++)
                            {      //itemString[0] = item ID, itemString[1] = item Name, itemString[2] = item Price, itemString[3] = item Type!
                                Item newItem = new Item(itemString[1], parsedVariable, itemString[3]);

                                returnList.Add(newItem);
                            }
                            returnDictionary.Add(id, returnList);
                        }
                        catch (Exception)
                        {
                        }
                    }

                }
            }
            catch
            {

            }
            return returnDictionary;
        }

    }
}
