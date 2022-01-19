using System;
using System.Collections.Generic;

namespace CafeLibrary
{
    public class MenuItem
    {
        //public List<string> ingredients = new List<string>();
        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }
    }
}
