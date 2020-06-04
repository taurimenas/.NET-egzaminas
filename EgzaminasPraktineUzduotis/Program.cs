using ClassLibrary;
using EgzaminasPraktineUzduotis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EgzaminasPraktineUzduotis
{
    class Program
    {
        static void Main()
        {
            ClientProcessor clientProcessor = new ClientProcessor();
            //PaymentData payments = new PaymentData();
            List<Customer> customers = CustomerData.AddCustomers();
            var customersById = clientProcessor.GetCustomerByCustomerId(customers, 1);
            var byCategory = clientProcessor.OrderByCategory(customersById);
            foreach (var item in byCategory)
            {
                Console.WriteLine(item);
            }
            var compare = clientProcessor.CompareMonthlyPayments(customersById);
            Console.WriteLine(compare);
        }
    }
}
