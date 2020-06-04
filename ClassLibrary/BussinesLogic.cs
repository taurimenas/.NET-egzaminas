using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class ClientProcessor
    {
        public Customer GetCustomerByCustomerId(List<Customer> clientList, int customerId)
        {
            var result = clientList.Where(x => x.CustomerId == customerId).ToList();
            return result[0];
        }
        public List<Payment> GetPaymentsOfThisMonthByCustomerId(Customer customer, Month month)
        {
            return customer.Payments.Where(x => x.MonthId == month).ToList();
        }
        public Dictionary<string, int> GetSumsOfPayments(Customer customer)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int sumLastMonth = customer.Payments.Where(x => x.MonthId == Month.LastMonth).Sum(x => x.Price);
            int sumThisMonth = customer.Payments.Where(x => x.MonthId == Month.ThisMonth).Sum(x => x.Price);
            result.Add("SumLastMonth", sumLastMonth);
            result.Add("SumThisMonth", sumThisMonth);
            result.Add("Sum", sumThisMonth + sumLastMonth);
            return result;
        }
        public List<Payment> OrderByCategory(Customer customer)
        {
            return customer.Payments.OrderBy(x => x.Category).ToList();
        }
        public string CompareMonthlyPayments(Customer customer)
        {
            int sumLastMonth = customer.Payments.Where(x => x.MonthId == Month.LastMonth).Sum(x => x.Price);
            int sumThisMonth = customer.Payments.Where(x => x.MonthId == Month.ThisMonth).Sum(x => x.Price);
            return $"This month customer {customer.CustomerId} spent {sumThisMonth}. Last month customer {customer.CustomerId} spent {sumLastMonth}";
        }
        public void PrintReport()
        {

        }

    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Payment> Payments { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Payment
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Month MonthId { get; set; }
        public override string ToString()
        {
            return $"{Price} {Description} {Category} {MonthId}";
        }
    }

    public enum Category
    {
        Food,
        Taxes,
        Entertainment
    }
    public enum Month
    {
        LastMonth,
        ThisMonth
    }

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
                Name = "Laura",
                LastName = "Antanaite",
                Payments = PaymentData.AddPayments(),
            };
            customers.Add(client);
            customers.Add(client2);
            customers.Add(client3);
            return customers;
        }
    }
    public class PaymentData
    {
        static List<Payment> Payments = new List<Payment>();
        public static List<Payment> AddPayments()
        {
            Payment payment1 = new Payment()
            {
                Price = 1,
                Description = "Payment for milk.",
                Category = Category.Food,
                MonthId = Month.LastMonth
            };
            Payment payment2 = new Payment()
            {
                Price = 50,
                Description = "Payment for concert.",
                Category = Category.Entertainment,
                MonthId = Month.LastMonth
            };
            Payment payment3 = new Payment()
            {
                Price = 40,
                Description = "Payment for electricity.",
                Category = Category.Taxes,
                MonthId = Month.ThisMonth
            };
            Payment payment4 = new Payment()
            {
                Price = 20,
                Description = "Payment for internet.",
                Category = Category.Taxes,
                MonthId = Month.ThisMonth
            };
            Payments.Add(payment1);
            Payments.Add(payment2);
            Payments.Add(payment3);
            Payments.Add(payment4);
            return Payments;
        }
    }
}
