﻿using System;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public PetType Type { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime SoldDate { get; set; }
        
        public string Color { get; set; }
        
        public double Price { get; set; }
    }
}