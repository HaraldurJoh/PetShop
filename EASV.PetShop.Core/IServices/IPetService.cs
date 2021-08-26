using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();

        void CreatePet(Pet pet);

        void DeletePet(int pet);

        void UpdatePet(Pet pet);
        
    }
}