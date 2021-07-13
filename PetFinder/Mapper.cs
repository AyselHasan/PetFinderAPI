using AutoMapper;
using PetFinder.API.Client.DTOs;
using PetFinder.API.Manage.DTOs;
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
            CreateMap<LocationCreateDTO, Location>();
            CreateMap<ColorCreateDTO, Color>();
            CreateMap<ContactCreateDTO, Contact>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryGetDTO>();
            CreateMap<Category, CategoryItemDTO>();
        }
    }
}
