using System.Collections.Generic;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuItemsTests
{
    [TestClass]
    public class MenuItemsObjectTests
    {
        [TestMethod]
        public void TestConstructor_ShouldSetCorrectValues ()
        {
            MenuItem burger = new MenuItem(2, "Burger", "Meaty goodness", new List<string> {"Beef", "Buns", "Cheese"}, 5.99m); 

            Assert.AreEqual("Burger", burger.MealName);
            CollectionAssert.AreEqual(new List<string> {"Beef", "Buns", "Cheese"}, burger.Ingredients);
        }
    }
}
