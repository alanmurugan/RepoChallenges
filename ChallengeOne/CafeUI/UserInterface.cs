using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;

namespace CafeUI
{
    public class UserInterface
    {
        private readonly MenuItemsRepository _repo = new MenuItemsRepository();

        public void Run()
        {
            SeedContent();
            RunUI();
        }
        private void RunUI()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                System.Console.WriteLine(
                    "Enter the number of your selection: \n" +
                    "1. Show all meals in menu \n" +
                    "2. Add new meal to menu \n" +
                    "3. Remove meal from menu \n" +
                    "4. Exit"
                );
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        //Show all meals in menu
                        DisplayAllMenuItems();
                        break;
                    case "2":
                        //Add new meal to menu
                        AddNewMenuItem();
                        break;
                    case "3":
                        //Delete meal from menu
                        DeleteMenuItem();
                        break;
                    case "4":
                        //Exit
                        System.Console.WriteLine("Thank you!");
                        isRunning = false;
                        break;
                    default:
                        //What to do with invalid input
                        System.Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        //Show all meals in menu method
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _repo.GetMenuItems();
            foreach (MenuItem item in listOfMenuItems)
            {
                printMenuItem(item);
            }
            Continue();
        }

        //Add new meal to menu method
        private void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.Write("Enter the meal number: ");
            newItem.MealNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter a meal name: ");
            newItem.MealName = Console.ReadLine();

            Console.Write("Enter a meal description: ");
            newItem.Description = Console.ReadLine();

            Console.Write("Enter the meal's ingredients (use , between ingredients): ");
            newItem.Ingredients = Console.ReadLine().Split(',').ToList();

            Console.Write("Enter meal's price: ");
            newItem.Price = decimal.Parse(Console.ReadLine());

            _repo.AddMenuItem(newItem);
            System.Console.WriteLine($"New meal {newItem.MealName} was added!");
        }

        //Remove meal from menu method
        private void DeleteMenuItem()
        {
            Console.Clear();
            System.Console.WriteLine("Select which meal you want to remove: ");

            List<MenuItem> menuItemsList = _repo.GetMenuItems();
            int count = 1;
            foreach (MenuItem item in menuItemsList)
            {
                System.Console.WriteLine(count + ". " + item.MealName);
                count++;
            }

            int selection = int.Parse(Console.ReadLine());
            int targetIndex = selection - 1;

            if (targetIndex >= 0 && targetIndex < menuItemsList.Count)
            {
                MenuItem targetMenuItem = menuItemsList[targetIndex];
                if (_repo.DeleteMenuItem(targetMenuItem))
                {
                    System.Console.WriteLine($"{targetMenuItem.MealName} was deleted successfully");
                }
                else
                {
                    System.Console.WriteLine("Something went wrong.");
                }
            }
            else
            {
                System.Console.WriteLine("Invalid selection");
            }
            Continue();
        }


        private void printMenuItem(MenuItem item)
        {
            System.Console.WriteLine(
                $"Meal Number: {item.MealNumber} \n" +
                $"Meal Name: {item.MealName} \n" +
                $"Meal Description: {item.Description} \n" +
                $"Meal Ingredients: {string.Join(",", item.Ingredients)} \n" +
                $"Meal Price: {item.Price} \n"
            );
        }
        private void Continue()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            MenuItem breakfastBowl = new MenuItem(1, "Loaded Breakfast Bowl", "Everything you need to start your day!", new List<string> { "Eggs", "Potatoes", "Red Onions", "Ham", "Cheddar Cheese" }, 7.99m);
            MenuItem omlette = new MenuItem(2, "Cali Omlette", "A west coast brunch classic!", new List<string> { "Eggs", "Bacon", "White Cheddar Cheese", "Avacado", "Sour Cream", "Peppers" }, 9.99m);
            MenuItem frenchToast = new MenuItem(3, "Croissant French Toast", "Indulgent spin on a breakfast standard", new List<string> { "Croissant", "Egg", "Brown Sugar", "Cinnamon", "Powdered Sugar", "Pecans", "Syrup", "Strawberries", "Blueberries" }, 11.99m);
            MenuItem bagelSandwich = new MenuItem(4, "Smoked Salmon Bagel", "A delicious New York staple", new List<string> { "Bagel", "Smoked Salmon", "Tomatoes", "Cream Cheese", "Red Onions", "Capers" }, 10.99m);
            MenuItem eggsBenedict = new MenuItem(5, "Eggs Benedict", "Decadent brunch standard, elevated to luxury", new List<string> { "Eggs", "Ham", "English Muffin", "Hollandaise Sauce", "Truffles", "Caviar" }, 19.99m);

            _repo.AddMenuItem(breakfastBowl);
            _repo.AddMenuItem(omlette);
            _repo.AddMenuItem(frenchToast);
            _repo.AddMenuItem(bagelSandwich);
            _repo.AddMenuItem(eggsBenedict);
        }
    }
}