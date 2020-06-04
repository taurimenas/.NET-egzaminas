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
        ClientProcessor clientProcessor = new ClientProcessor();
        List<Customer> customers = CustomerData.AddCustomers();


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
        [Fact]
        public void ShouldGetCorrectlyOrderedListByCategory()
        {
            // Arrange
            List<Payment> expected = customers[0].Payments.OrderBy(x => x.Category).ToList();
            // Act
            List<Payment> actual = clientProcessor.OrderByCategory(customers[0]);
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
            List<Payment> actual = clientProcessor.GetPaymentsOfThisMonthByCustomerId(customers[0], month);
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
    }
}
