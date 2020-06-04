using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        readonly ClientProcessor clientProcessor = new ClientProcessor();
        readonly List<Customer> customers = CustomerData.AddCustomers();

        [Fact]
        public void ShouldGetOneCustomerByCustomerId()
        {
            // Arrange
            Customer expected = customers[0];
            // Act
            Customer actual = clientProcessor.GetCustomerByCustomerId(customers, 1);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("EntertainmentFoodTaxesTaxes")]
        public void ShouldGetCorrectlyOrderedListByCategory(string expected)
        {
            // Arrange
            // Act
            List<Payment> actualList = clientProcessor.OrderByCategory(customers[0]);
            string actual = "";
            foreach (var item in actualList)
            {
                actual += item.Category.Name;
            }
            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(Month.LastMonth)]
        [InlineData(Month.ThisMonth)]
        public void ShouldGetPaymentsListOfSelectedMonth(Month month)
        {
            // Arrange
            List<Payment> expected = customers[0].Payments.Where(x => x.MonthId == month).ToList();
            // Act
            List<Payment> actual = clientProcessor.GetPaymentsOfSelectedMonthByCustomerId(customers[0], month);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("This month customer 1 spent 60. Last month customer 1 spent 51")]
        public void ShouldReturnStringThatComparesMonthlyPayments(string expected)
        {
            // Arrange
            // Act
            string actual = clientProcessor.CompareMonthlyPayments(customers[0]);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Food 1 Taxes 0 Entertainment 50 ", Month.LastMonth)]
        [InlineData("Food 0 Taxes 60 Entertainment 0 ", Month.ThisMonth)]
        public void SumByCategoryFilterShouldWork(string expected, Month month)
        {
            // Arrange
            // Act
            string actual = "";
            var result = clientProcessor.SumByCategory(customers[0], month);
            foreach (var item in result)
            {
                actual += $"{item.Key.Name} {item.Value} ";
            }
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Food Entertainment ")]
        public void CompererShouldShowCorrectCategoriesWithSums(string expected)
        {
            // Arrange
            // Act
            string actual = "";
            var result = clientProcessor.CompareSpendings(customers[0]);
            foreach (var item in result)
            {
                actual += $"{item} ";
            }
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Taxes", 50, Month.ThisMonth)]
        [InlineData("Entertainment", 10, Month.LastMonth)]
        [InlineData("FoodEntertainment", 0, Month.LastMonth)]
        public void ShouldGetCategoriesAboveLimit(string expected, int limit, Month month)
        {
            // Arrange
            // Act
            string actual = "";
            var result = clientProcessor.GetCategoryWithAboveLimit(customers[0], limit, month);
            foreach (var item in result)
            {
                actual += $"{item}";
            }
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
