using System.Collections.Generic;

namespace ClassLibrary
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
