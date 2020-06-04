using System.Collections.Generic;

namespace ClassLibrary
{
    public class CustomerData
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Customer> AddCustomers()
        {
            Customer client = new Customer()
            {
                CustomerId = 1,
                Name = "Tauras",
                LastName = "Slip",
                Payments = PaymentData.AddPayments(),
            };
            Customer client2 = new Customer()
            {
                CustomerId = 1,
                Name = "Tomas",
                LastName = "Antanaitis",
                Payments = PaymentData.AddPayments(),
            };
            Customer client3 = new Customer()
            {
                CustomerId = 1,
                Name = "Ona",
                LastName = "Antanaite",
                Payments = PaymentData.AddPayments(),
            };
            customers.Add(client);
            customers.Add(client2);
            customers.Add(client3);
            return customers;
        }
    }
}
