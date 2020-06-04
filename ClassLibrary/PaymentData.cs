using System.Collections.Generic;

namespace ClassLibrary
{
    public class PaymentData
    {
        public static List<Payment> AddPayments()
        {
            List<Payment> Payments = new List<Payment>();
            Payment payment1 = new Payment()
            {
                Price = 1,
                Description = "Payment for milk.",
                Category = new Categories().SelectCategory("Food"),
                MonthId = Month.LastMonth
            };
            Payment payment2 = new Payment()
            {
                Price = 50,
                Description = "Payment for concert.",
                Category = new Categories().SelectCategory("Entertainment"),
                MonthId = Month.LastMonth
            };
            Payment payment3 = new Payment()
            {
                Price = 40,
                Description = "Payment for electricity.",
                Category = new Categories().SelectCategory("Taxes"),
                MonthId = Month.ThisMonth
            };
            Payment payment4 = new Payment()
            {
                Price = 20,
                Description = "Payment for internet.",
                Category = new Categories().SelectCategory("Taxes"),
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
