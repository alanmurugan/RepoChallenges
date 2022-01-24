using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;

namespace BadgeUI
{
    public class UserInterface
    {
        private BadgeRepository _repo = new BadgeRepository();
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
                    "Hello Security Admin. What Would you like to do? \n" +
                    "Enter the number of your selection: \n" +
                    "1. Add a badge \n" +
                    "2. Update a badge \n" +
                    "3. List all badges \n"
                );
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        //Update a badge
                        break;
                    case "3":
                        //List all badges
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice!");
                        Continue();
                        break;
                }
            }
        }
        private void AddNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge(0, new List<string> {}, null);

            System.Console.WriteLine("What is the Badge ID Number: ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            _repo.AddBadge(newBadge);
            System.Console.WriteLine("What is a door that it needs access to: ");
            _repo.AddDoor(newBadge, Console.ReadLine());
            bool moreDoors = true;
            while (moreDoors)
            {
                System.Console.WriteLine("Any other doors? (y/n)");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    System.Console.WriteLine("What is a door that it needs access to: ");
                    _repo.AddDoor(newBadge, Console.ReadLine());
                    continue;
                }
                else if (choice == "n")
                {
                    Continue();
                    moreDoors = false;
                }
            }
        }
        private void UpdateBadge(){
            Console.Clear();
            System.Console.WriteLine("What Badge ID Number needs updating?: ");
            int inputBadgeID = int.Parse(Console.ReadLine());
            
        }

        private void ShowAllBadges(){
            Console.Clear();
            System.Console.WriteLine();
        }
        private void SeedContent()
        {
            Badge alyssa = new Badge(2342, new List<string> { "A1", "A2", "A3", "B2" }, "Alyssa");
            Badge alan = new Badge(5622, new List<string> { "A1", "B1", "B2", "C3" }, "Alan");
            Badge tGuy = new Badge(44312, new List<string> { "C2", "D2" }, "That Guy");
            Badge xOne = new Badge(12345, new List<string> { "A5", "A7" }, "Example One");
            Badge xTwo = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" }, "Example Two");
            Badge xThree = new Badge(32345, new List<string> { "A4", "A5" }, "Example Three");
            _repo.AddBadge(alyssa);
            _repo.AddBadge(alan);
            _repo.AddBadge(tGuy);
            _repo.AddBadge(xOne);
            _repo.AddBadge(xTwo);
            _repo.AddBadge(xThree);
        }
        private void Continue()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}