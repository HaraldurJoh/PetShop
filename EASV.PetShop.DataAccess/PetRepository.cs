using System;
using System.Collections.Generic;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int nextID = 1;

        public PetRepository()
        {
            PetType dog = new PetType{ ID = 1, Name = "Dog" };
            PetType cat = new PetType{ ID = 2, Name = "Cat" };

            Pet nala = new Pet
            {
                Name = "Schwanz", Color = "Blå", Type = cat, Birthdate = DateTime.Now, SoldDate = DateTime.Now,
                Price = 12.00
            };
            Pet hugo = new Pet
            {
                Name = "Hugo Helmig", Color = "Sort", Type = cat, Birthdate = DateTime.Now, SoldDate = DateTime.Now,
                Price = 120.00
            };

            AddPet(nala);
            AddPet(hugo);
        }

        public List<Pet> ReadAllPets()
        {
            return _petTable;
        }

        public Pet AddPet(Pet pet)
        {
            pet.ID = nextID;
            _petTable.Add(pet);

            nextID++;
            return pet;
        }
    }
}