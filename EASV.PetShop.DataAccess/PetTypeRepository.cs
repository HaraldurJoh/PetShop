using System.Collections.Generic;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static readonly List<PetType> PetTypeTable = new List<PetType>();

        public PetTypeRepository()
        {
            var cat = new PetType {Id = 1, Name = "Cat"};
            var dog = new PetType {Id = 2, Name = "Dog"};
            var goat = new PetType {Id = 3, Name = "Goat"};
            var pig = new PetType {Id = 4, Name = "Pig"};
            PetTypeTable.AddRange(new List<PetType>{cat,dog,goat,pig});
        }

        public List<PetType> GetAllPetTypes()
        {
            return PetTypeTable;
        }

        public PetType GetById(int id)
        {
            foreach (PetType petType in PetTypeTable)
            {
                if (petType.Id == id)
                {
                    return petType;
                }
            }

            return null;
        }
    }
}