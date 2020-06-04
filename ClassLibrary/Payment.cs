using System.Collections.Generic;

namespace ClassLibrary
{
    public class Payment
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Month MonthId { get; set; }
        public override string ToString()
        {
            return $"{Price} {Description} {Category.Name} {MonthId}";
        }
    }
}
