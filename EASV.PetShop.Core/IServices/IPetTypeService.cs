using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        public List<PetType> GetAllPetTypes();

        public PetType GetById(int id);
    }
}