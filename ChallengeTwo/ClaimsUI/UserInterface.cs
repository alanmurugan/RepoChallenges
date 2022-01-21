using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;

namespace ClaimsUI
{
    public class UserInterface
    {
        private ClaimsRepository _repo = new ClaimsRepository();
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
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter new claim \n" +
                    "4. Exit"
                );
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        TakeCare();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        System.Console.WriteLine("Ending claims program. Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        //invalid selection
                        break;
                }
            }
        }
        //Show all claims in columns
        private void ShowAllClaims()
        {
            Console.Clear();
            List<Claim> claimList = _repo.GetClaims();
            System.Console.WriteLine(
                "{0, -10} {1, -7} {2, -25} {3, -10} {4, -18} {5,-12} {6,-6}",
                "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            foreach (Claim claim in claimList)
            {
                WriteClaim(claim);
            }
            Continue();
        }
        private void TakeCare()
        {
            Console.Clear();
            List<Claim> claimList = _repo.GetClaims();
            System.Console.WriteLine(
                "{0, -10} {1, -7} {2, -25} {3, -10} {4, -18} {5,-12} {6,-6}",
                "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            WriteClaim(claimList[0]);
            System.Console.WriteLine("\n \n Do you want to deal with this claim now (y/n)? ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                System.Console.WriteLine($"You will be taking care of claim with Claim ID{claimList[0].ClaimID}");
                _repo.DeleteClaim(claimList[0]);
                Continue();
            }
            else if (choice.ToLower() == "n")
            {
                Continue();
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Invalid Selection. Press any key and try again.");
                Console.ReadKey();
                TakeCare();
            }
        }
        private void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            System.Console.WriteLine("Enter a ClaimID number: ");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            System.Console.WriteLine(
                "Claim Type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");
            System.Console.WriteLine("\nSelect number for claim's type");
            string claimTypeChoice = Console.ReadLine();
            switch (claimTypeChoice)
            {
                case "1":
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    System.Console.WriteLine("Invalid Choice. Press any key to return to main menu and try again.");
                    Console.ReadKey();
                    break;
            }

            System.Console.WriteLine("Enter a short description of claim: ");
            newClaim.ClaimDescription = Console.ReadLine();

            System.Console.WriteLine("Enter estimated amount of damage: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the date of the incident [yyyy/MM/dd]: ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the date the claim was filed [yyyy/MM/dd]: ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            System.Console.WriteLine(
                "{0, -10} {1, -7} {2, -25} {3, -10} {4, -18} {5,-12} {6,-6}",
                "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            WriteClaim(newClaim);
            System.Console.WriteLine("\n\nIs this information correct (y/n)?");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                _repo.AddClaim(newClaim);
                System.Console.WriteLine($"Claim with ID of {newClaim.ClaimID} has been added.");
                Continue();
            }
            else
            {
                System.Console.WriteLine("Claim was not added. Returning to main menu.");
                Continue();
            }
        }
        private void WriteClaim(Claim claim)
        {
            System.Console.WriteLine(
                "{0, -10} {1, -7} {2, -25} {3, -10} {4, -18} {5,-12} {6,-6}",
                claim.ClaimID, claim.ClaimType, claim.ClaimDescription, claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid
            );
        }

        private void SeedContent()
        {
            Claim george = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2022, 4, 25), new DateTime(2022, 4, 27));
            Claim leslie = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2022, 4, 11), new DateTime(2022, 4, 12));
            Claim haas = new Claim(3, ClaimType.Theft, "Stole pancakes", 4.00m, new DateTime(2022, 4, 27), new DateTime(2022, 6, 1));
            _repo.AddClaim(george);
            _repo.AddClaim(leslie);
            _repo.AddClaim(haas);
        }
        private void Continue()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}