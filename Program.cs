using System;
using System.Collections.Generic;

namespace Coffee
{
    class Program
    {
        static List<(string itemName, double itemPrice)> MenuItem = new List<(string, double)>();
        static List<(string itemName, double itemPrice)> Order = new List<(string, double)>();

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void AddMenuItem()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();
            Console.Write("Enter item price: ");
            double itemPrice = Convert.ToDouble(Console.ReadLine());

            MenuItem.Add((itemName, itemPrice));
            Console.WriteLine("Item added successfully!");

        }

        static void ViewMenu()
        {
            if (MenuItem.Count == 0)
            {
                Print("The menu is empty.");
            }
            Print("Menu:");
            for (int i = 0; i < MenuItem.Count; i++)
            {
                Print($"{i + 1}. {MenuItem[i].itemName} - ${MenuItem[i].itemPrice}");
            }

        }

        static void PlaceOrder()
        {
            if (MenuItem.Count == 0)
            {
                Print("No items ordered yet.");
                return;
            }
            ViewMenu();
            Print("Enter the item number to order: ");
            int itemNumber = Convert.ToInt32(Console.ReadLine());

            if (itemNumber > 0 && itemNumber <= MenuItem.Count)
            {
                Order.Add(MenuItem[itemNumber - 1]);
                Print("Item added to order!");
            }
            else
            {
                Print("Invalid item number.");
            }
        }
        static void ViewOrder()
        {
            if (Order.Count == 0)
            {
                Print("Your Oder is empty! ");
                return;
            }
            Print("Your order: ");
            foreach (var item in Order)
            {
                Print($"{item.itemName} - ${item.itemPrice}");
            }
        }


        static void CalculateTotal()
        {
            double totalAmount = 0;
            foreach (var item in Order)
            {
                totalAmount += item.itemPrice;
            }
            Print($"Total Amount Payable: ${totalAmount}");
        }

        static void Main()
        {
            Print("Welcome to the Coffee Shop!");
            while (true)
            {
                Print("1. Add Menu Item");
                Print("2. View Menu");
                Print("3. Place Order");
                Print("4. View Order");
                Print("5. Calculate Total");
                Print("6. Exit");

                Print("Select an option: ");
                int Option = Convert.ToInt32(Console.ReadLine());

                if (Option == 1)
                {
                    AddMenuItem();
                }
                else if (Option == 2)
                {
                    ViewMenu();
                }
                else if (Option == 3)
                {
                    PlaceOrder();
                }
                else if (Option == 4)
                {
                    ViewOrder();

                }
                else if (Option == 5)
                {
                    CalculateTotal();

                }
                else if (Option == 6)
                {
                    break;
                }
                else
                {
                    Print("Invalid option, please try again.");
                }
                Print("");
            }
        }
    }
}
