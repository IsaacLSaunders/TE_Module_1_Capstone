using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.WebSockets;
using System.Text;

namespace Capstone.Classes
{   //At vendimg machine start of run,, Run() with welcome message then displays Main menu
    //Needs access to VendingMachine to run its methods. Vending Mahcine has accountant and inventory access
    //DO WHILE--> while userSellection != 3 (exit selections in both menus)
    public class Menu
    {
        public VendingMachine VM = null;

        public Menu(VendingMachine vm)
        {
            VM = vm;
        }
        public void Run()
        {
            //At machine's start-->Welcome Message-->Displays MainMenu(Runs MainMenu method)
            Console.WriteLine("Welcome to Vendo-Matic 8000! 10 times better than the Vendo-Matic 800!!!");

            MainMenu();

        }
        public void MainMenu()
        {
            Logger.DeleteLog();
            //Displays our menu options and asks the user for numerical input until the user chooses 3)
            bool choseOption3 = false;
            while (!choseOption3)
            {
                int parsedSelection = 0;

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Please make a numerical selection, 1-3.");
                    Console.WriteLine("1) Display Items");
                    Console.WriteLine("2) Purchase");
                    Console.WriteLine("3) Exit");
                    string userSelection = Console.ReadLine();

                    //parse string input to int
                    parsedSelection = int.Parse(userSelection);
                    if (parsedSelection > 4 || parsedSelection < 1)
                    {
                        throw new Exception();
                    }

                    //For option 1-->Run(vm.Inventory.Display)
                    if (parsedSelection == 1)
                    {
                        VM.inventory.DisplayInventory();
                    }

                    //For option 2-->Run(PurchaseMenu)
                    else if (parsedSelection == 2)
                    {
                        PurchaseMenu();
                    }

                    //For option 3-->return
                    else if (parsedSelection == 3)
                    {
                        choseOption3 = true;
                        Console.WriteLine();
                        Console.WriteLine("Thanks for using the Vendo-Matic 8000! Have a snacktastic day!");
                    }
                }
                catch (Exception)
                {
                    //catch invalids & provide error messages
                    Console.WriteLine("That is not a valid selection.");
                }

            }

            return;

        }
        public void PurchaseMenu()
        {
            //Displays our menu options and asks the user for numerical input until the user chooses 3)
            bool choseOption3 = false;
            while (!choseOption3)
            {
                int parsedSelection = 0;

                try
                {
                    DisplayBalance();
                    Console.WriteLine("Please make a numerical selection, 1-3.");
                    Console.WriteLine("1) Feed Money");
                    Console.WriteLine("2) Select Product");
                    Console.WriteLine("3) Finish Transaction");
                    string userSelection = Console.ReadLine();

                    //parse string input to int
                    parsedSelection = int.Parse(userSelection);
                    if (parsedSelection > 3 || parsedSelection < 1)
                    {
                        throw new Exception();
                    }
                    //For option 1-->Run(vm.Inventory.Display)
                    else if (parsedSelection == 1)
                    {
                        //For option 1-->Feed Money(vm.Accountant.IncrementBalance)
                        FeedMoney();
                    }

                    //For option 2-->Run(PurchaseMenu)
                    else if (parsedSelection == 2)
                    {
                        //For option 2-->Select Product(vm.SelectItemByCode)
                        SelectProduct();
                    }

                    //For option 3-->return
                    else
                    {
                        //For option 3-->Finish Transaction (vm.Accountant.DispenseChange && Main)
                        VM.accountant.DispenseChange();
                        choseOption3 = true;
                    }
                }
                catch (Exception)
                {
                    //catch invalids & provide error messages
                    Console.WriteLine("That is not a valid selection.");
                }

            }

            return;



        }
        public void FeedMoney()
        {
            bool validUserInput = false;
            decimal moneyIn = 0.00M;

            //prompt user "how much wanna add"


            while (!validUserInput)
            {
                try
                {
                    Console.WriteLine("How much would you like to add? This machine only accepts whole dollar amounts.");
                    string userInput = Console.ReadLine();

                    //take input, parse, hold as decimal etc trycatch
                    moneyIn = decimal.Parse(userInput);
                    validUserInput = true;
                }
                catch (Exception)
                {

                    Console.WriteLine("That is not a valid input");
                }
            }
            //run incrementbalance with userinput
            VM.accountant.IncrementBalance(moneyIn);

            return;
        }
        public void SelectProduct()
        {
            bool validUserInput = false;



            while (!validUserInput)
            {
                VM.inventory.DisplayInventory();
                DisplayBalance();
                Console.WriteLine("Which product would you like to enjoy today? Please select a product ID.");
                Console.WriteLine("Write EXIT, to return to the previous menu.");
                string productId = Console.ReadLine().ToUpper();
                if (!(productId == "EXIT"))
                {
                    if (!string.IsNullOrEmpty(productId) && VM.inventory.ItemLocations.ContainsKey(productId))
                    {
                        if (VM.inventory.ItemLocations[productId].Count > 0)
                        {
                            if (VM.accountant.Balance >= VM.inventory.ItemLocations[productId][0].Price)
                            {
                                validUserInput = VM.SelectItemByCode(productId);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Funds. Please add more money.");
                                Console.WriteLine("Returning to Purchase Process menu.");
                                validUserInput = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This item is out of stock.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid selection.");
                    }
                }
                else
                {
                    validUserInput = true;
                }


            }
            return;
        }

        public void DisplayBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"Your current Balance is {VM.accountant.Balance}");
            Console.WriteLine();
        }
    }
}
