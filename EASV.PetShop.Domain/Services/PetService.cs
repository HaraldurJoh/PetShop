using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadAllPets();
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }

        public void DeletePet(Pet id)
        {
            _petRepository.DeletePet(id);
        }
    }
}