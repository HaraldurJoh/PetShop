using System;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.UI
{
    internal class Menu
    {
        private static IPetService _petService;
        private static IPetTypeService _petTypeService;

        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        public void ShowMenu()
        {
            WelcomeGreeting();
            StartLoop();
        }
        
        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    SeeAllPets();
                } 
                
                if (choice == 2)
                {
                    CreatePet();
                }

                if (choice == 3)
                {
                    throw new NotImplementedException(); //edit
                }

                if (choice == 4)
                {
                    DeletePet();
                }
                PrintNewLine();
            }
        }

        private void DeletePet()
        {
            SeeAllPets();
            PrintNewLine();
            Console.WriteLine("Select a pet to delete, by typing the id and hit enter");
            
            var idString = Console.ReadLine();
            int idToDelete = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToDelete = id;
            }

            _petService.DeletePet(idToDelete);
            PrintNewLine();
            Console.WriteLine("The pet has been deleted");
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            PrintNewLine();
            var selectionString = Console.ReadLine();
            if (int.TryParse(selectionString, out var selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Print("1 - See all pets");
            Print("2 - Create a pet");
            Print("3 - Edit a pet");
            Print("4 - Delete a pet");
            Print("0 - Exit");
        }
        private void WelcomeGreeting()
        {
            Print("Welcome to the pet shop!");
            Print("You have the following options:");
        }
        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private void PrintNewLine()
        {
            Print(" ");
        }

        private void SeeAllPetTypes()
        {
            var petTypes = _petTypeService.GetAllPetTypes();
            foreach (PetType p in petTypes)
            {
                Print($"ID: {p.Id} | {p.Name}");
            }
        }
        
        private void SeeAllPets()
        {
            Print("All pets:");
            var pets = _petService.GetAllPets();
            foreach(Pet p in pets)
            {
                Print($"{p.Id}, {p.Name}, {p.Type.Name}, {p.Color}, {p.Birthdate}, {p.SoldDate}, {p.Price}");
            }
        }

        private void CreatePet()
        {
            Print("Please enter a pet name:");
            string petName = Console.ReadLine();
            PrintNewLine();

            Print("Please select a Pet Type ID:");
            SeeAllPetTypes();
            var petType = Console.ReadLine();
            int selection;
            while (!int.TryParse(petType, out selection))
            {
                Print("You did not type a number! Try again!");
                petType = Console.ReadLine();
            }

            while (_petTypeService.GetById(selection) == null)
            {
                Print("Selected ID does not exist! Try again!");
                petType = Console.ReadLine();
            }

            PetType pt = _petTypeService.GetById(selection);
            
            Print("Please enter a color:");
            string petColor = Console.ReadLine();
            PrintNewLine();
            
            Print("Please enter birthdate: (Format: DD-MM-YYYY)");
            string petBirthUnformatted = Console.ReadLine();
            DateTime petBirthday = DateTime.Parse(petBirthUnformatted);
            PrintNewLine();
            
            Print("Please enter sold date: (Format: DD-MM-YYYY)");
            string petSoldUnformatted = Console.ReadLine();
            DateTime petSoldDate = DateTime.Parse(petSoldUnformatted);
            PrintNewLine();
            
            Print("Please enter price:");
            string petPriceUnformatted = Console.ReadLine();
            double petPrice = double.Parse(petPriceUnformatted);
            PrintNewLine();

            Print("Swag! Your pet was created!");
            _petService.CreatePet(
                new Pet
                {
                    Name = petName, Color = petColor, Birthdate = petBirthday, SoldDate = petSoldDate, Type = pt, Price = petPrice
                }
            );
        }
    }
}