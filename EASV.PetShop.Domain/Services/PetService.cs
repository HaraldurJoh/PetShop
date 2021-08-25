using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;

        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }
        
        public List<Pet> GetAllPets()
        {
            return _repo.ReadAllPets();
        }

        public Pet CreatePet(Pet pet)
        {
            return _repo.AddPet(pet);
        }
    }
}