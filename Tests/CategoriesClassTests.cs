using Autofac.Extras.Moq;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class CategoriesClassTests
    {

        [Theory]
        [InlineData("Grocery", "FoodTaxesEntertainmentGrocery")]
        public void ShouldAddNewCategoryByGivenName(string name, string expected)
        {
            using var mock = AutoMock.GetLoose();
            var categories = mock.Mock<Categories>();
            categories.Object.AddNewCategory(name);
            string actual = "";
            foreach (var item in Categories.categoryList)
            {
                actual += item.Name;
            }
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("FoodTaxesEntertainment")]
        public void ShouldPrintAllItemsInCategoryList(string expected)
        {
            Categories categories = new Categories();
            string actual = categories.GetCategoryListNames();
            Assert.Equal(expected, actual);
        }
    }
}
