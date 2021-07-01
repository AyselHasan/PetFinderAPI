using AutoMapper;
using PetFinder.Data.Entities;
using PetFinder.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<BreedCreateDTO, Breed>();
        }
    }
}
