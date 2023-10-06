using Capstone.Classes.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {
        public void Run()
        {
            VMEmployee employee = new VMEmployee();
            VendingMachine vendingMachine = new VendingMachine(employee.StockVM());

            Menu menu = new Menu(vendingMachine);

            menu.Run();
        }
    }
}
