using System;
using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.DataAccess;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.Domain.Services;

namespace EASV.PetShop.UI
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();
            IPetTypeRepository petTypeRepository = new PetTypeRepository();

            IPetService petService = new PetService(petRepository);
            IPetTypeService petTypeService = new PetTypeService(petTypeRepository);

            Menu menu = new Menu(petService, petTypeService);
            menu.ShowMenu();
        }
    }
}