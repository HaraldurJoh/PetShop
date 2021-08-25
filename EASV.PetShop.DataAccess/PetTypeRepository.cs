using System.Collections.Generic;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> _petTypeTable = new List<PetType>();

        public PetTypeRepository()
        {
            //Available pet types
            PetType cat = new PetType {ID = 1, Name = "Cat"};
            PetType dog = new PetType {ID = 2, Name = "Dog"};
            PetType goat = new PetType {ID = 3, Name = "Goat"};
            PetType pig = new PetType {ID = 4, Name = "Pig"};
            _petTypeTable.AddRange(new List<PetType>{cat,dog,goat,pig});
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeTable;
        }

        public PetType GetByID(int id)
        {
            foreach (PetType petType in _petTypeTable)
            {
                if (petType.ID == id)
                {
                    return petType;
                }
            }

            return null;
        }
    }
}