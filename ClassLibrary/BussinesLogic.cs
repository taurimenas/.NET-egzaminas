using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class ClientProcessor
    {
        public Customer GetCustomerByCustomerId(List<Customer> customerList, int customerId)
        {
            var result = customerList.Where(x => x.CustomerId == customerId).ToList();
            var sum = result[0];
            return result[0];
        }
        public List<Payment> GetPaymentsOfSelectedMonthByCustomerId(Customer customer, Month month)
        {
            return customer.Payments.Where(x => x.MonthId == month).ToList();
        }
        public List<Payment> OrderByCategory(Customer customer)
        {
            return customer.Payments.OrderBy(x => x.Category.Name).ToList();
        }
        public string CompareMonthlyPayments(Customer customer)
        {
            int sumLastMonth = customer.Payments.Where(x => x.MonthId == Month.LastMonth).Sum(x => x.Price);
            int sumThisMonth = customer.Payments.Where(x => x.MonthId == Month.ThisMonth).Sum(x => x.Price);
            return $"This month customer {customer.CustomerId} spent {sumThisMonth}. Last month customer {customer.CustomerId} spent {sumLastMonth}";
        }
        public void SpendingAlert(Customer customer, List<string> listToPrint, string message)
        {
            foreach (var item in listToPrint)
            {
                message += $"{item} ";
            }
            Console.WriteLine(message);
        }

        public List<string> CompareSpendings(Customer customer)
        {
            List<string> result = new List<string>();
            var thisMonthData = SumByCategory(customer, Month.ThisMonth);
            var lastMonthData = SumByCategory(customer, Month.LastMonth);
            foreach (var item in thisMonthData)
            {
                if (lastMonthData.TryGetValue(item.Key, out int value))
                {
                    if (value >= item.Value * 1.5)
                    {
                        result.Add(item.Key.Name);
                    }
                }
            }
            return result;
        }
        public List<string> GetCategoryWithAboveLimit(Customer customer, int limit, Month month)
        {
            List<string> result = new List<string>();
            foreach (var item in SumByCategory(customer, month))
            {
                if (item.Value > limit)
                {
                    result.Add(item.Key.Name);
                }
            }
            return result;
        }
        public Dictionary<Category, int> SumByCategory(Customer customer, Month month)
        {
            List<Payment> payments = GetPaymentsOfSelectedMonthByCustomerId(customer, month);
            Dictionary<Category, int> result = new Dictionary<Category, int>();
            foreach (var category in Categories.categoryList)
            {
                result.Add(category, payments.Where(x => x.Category.Name == category.Name).Sum(x => x.Price));
            }
            return result;
        }
    }
}
