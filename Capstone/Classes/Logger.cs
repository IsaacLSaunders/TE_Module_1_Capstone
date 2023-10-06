using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Logger
    {
        /// <summary>
        /// Static method to log the details of adding money to the machine ||OR|| giving change from the machine at the end of a transaction.
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="logType"></param>
        /// <param name="amount"></param>
        /// <param name="balance"></param>
        public static void Log(string logType, decimal amount, decimal balance)
        {
            string directory = Environment.CurrentDirectory;

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(directory, "log.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now} {logType}: {amount} {balance}");
                }
            }
            catch (Exception)
            {
            }


        }
        
        /// <summary>
        /// Static method to log the details of dispensing and item from the machine.
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="item"></param>
        /// <param name="location"></param>
        /// <param name="amount"></param>
        /// <param name="balance"></param>
        public static void Log(string item, string location, decimal amount, decimal balance)
        {
            string directory = Environment.CurrentDirectory;

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(directory, "log.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now} {item} {location} {amount} {balance}");
                }
            }
            catch (Exception)
            {
            }


        }
    }
}
