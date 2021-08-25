using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        public List<PetType> GetAllPetTypes();

        public PetType GetByID(int id);
    }
}