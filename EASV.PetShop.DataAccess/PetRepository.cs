using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> PetTable = new List<Pet>();
        private static int _nextId = 1;

        public PetRepository()
        {
            PetType dog = new PetType{ Id = 1, Name = "Dog" };
            PetType cat = new PetType{ Id = 2, Name = "Cat" };

            Pet Schwanz = new Pet
            {
                Name = "Schwanz", Color = "Blå", Type = dog, Birthdate = DateTime.Now, SoldDate = DateTime.Now,
                Price = 12.00
            };
            Pet hugohelmig = new Pet
            {
                Name = "Hugo Helmig", Color = "Sort", Type = cat, Birthdate = DateTime.Now, SoldDate = DateTime.Now,
                Price = 120.00
            };

            AddPet(Schwanz);
            AddPet(hugohelmig);
        }

        public List<Pet> ReadAllPets()
        {
            return PetTable;
        }

        public Pet AddPet(Pet pet)
        {
            pet.Id = _nextId;
            PetTable.Add(pet);

            _nextId++;
            return pet;
        }

        public void DeletePet(Pet id)
        {
            List<Pet> pets = ReadAllPets();
            foreach (Pet pet in pets.ToList())
            {
                if (pet.Id.Equals(id))
                {
                    pets.Remove(pet);
                }
            }
        }

        public void EditPet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
