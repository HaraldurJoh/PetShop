using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        public List<Pet> ReadAllPets();

        public Pet AddPet(Pet pet);

        void DeletePet(int id);
        
        void EditPet(Pet pet);
    }
}