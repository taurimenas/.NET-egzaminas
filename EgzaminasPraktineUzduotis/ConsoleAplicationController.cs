using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EgzaminasPraktineUzduotis
{
    public class ConsoleAplicationController
    {
        public bool State = true;
        readonly ClientProcessor clientProcessor = new ClientProcessor();
        readonly List<Customer> customers = CustomerData.AddCustomers();
        public int CustomerId { get; set; }
        public void StartMessage()
        {
            Console.WriteLine($"There are {customers.Count()} costumers saved.");
            Console.WriteLine("To select costumer enter his id: ");
            //TODO: Add validation and exception handling
            int.TryParse(Console.ReadLine(), out int result);
            CustomerId = result;
            Console.Clear();
        }
        public void EndMessage()
        {
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public void StandardMessage()
        {
            Console.WriteLine("1 - Compare monthly payments");
            Console.WriteLine("2 - Show payments of this month");
            Console.WriteLine("3 - Show spending alert for this month");
            Console.WriteLine("4 - Show spending alert if you've reached your limit");
            Console.WriteLine("Esc to exit");
        }
        public void Select()
        {
            Console.WriteLine("Press number to select 1-4");
            KeyboardController();
        }
        private void KeyboardController()
        {
            var customer = clientProcessor.GetCustomerByCustomerId(customers, CustomerId);
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine(clientProcessor.CompareMonthlyPayments(customer));
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("Press NUM 1 to see this month or any key to see last month");
                    var tempKey = Console.ReadKey().Key;
                    Console.WriteLine();
                    if (tempKey == ConsoleKey.D1 || tempKey == ConsoleKey.NumPad1)
                        PrintList(customer, Month.ThisMonth);
                    else
                        PrintList(customer, Month.LastMonth);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    clientProcessor.SpendingAlert(customer, clientProcessor.CompareSpendings(customer), "This month you have spent 150% more in these categories: ");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    clientProcessor.SpendingAlert(customer, clientProcessor.GetCategoryWithAboveLimit(customer, 10, Month.ThisMonth), "You have reached your monthly limit in these categories: ");
                    break;
                case ConsoleKey.Escape:
                    State = false;
                    break;
                default:
                    break;
            }
        }
        private void PrintList(Customer customer, Month month)
        {
            foreach (var item in clientProcessor.GetPaymentsOfSelectedMonthByCustomerId(customer, month))
            {
                Console.WriteLine(item.ToString());
            };
        }
    }
}
