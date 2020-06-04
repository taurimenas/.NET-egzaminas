using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Categories
    {
        public static List<Category> categoryList = new List<Category>() {
            new Category() { Id = 1, Name = "Food" },
            new Category() { Id = 2, Name = "Taxes" },
            new Category() { Id = 3, Name = "Entertainment" }
        };
        public Category SelectCategory(string category)
        {
            return categoryList.Find(x => x.Name == category);
        }
        public void AddNewCategory(string name)
        {
            categoryList.Add(new Category() { Id = categoryList.Count + 1, Name = name });
        }
        public string GetCategoryListNames()
        {
            string result = "";
            foreach (var item in categoryList)
            {
                result += item.Name;
            }
            return result;
        }
    }
}
