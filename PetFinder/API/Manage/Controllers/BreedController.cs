using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.Data.Entities;
using PetFinder.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public BreedController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Get Breed
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Breed breed = await context.Breeds.FirstOrDefaultAsync(x => x.Id == id);

            if (breed == null)
            {
                return NotFound();
            }
            return Ok(breed.Name);
        }
        #endregion

        #region Get All Breeds
        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GelAllBreeds()
        {
            List<Breed> Breeds = await context.Breeds.ToListAsync();
            return Ok(Breeds);
        }
        #endregion

        #region Create Breeds
        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateBreeds(BreedCreateDTO breedCreatedto)
        {
            Breed newBreed = await context.Breeds.FirstOrDefaultAsync(x => x.Name == breedCreatedto.Name && x.IsDeleted == false);
            #region check
            if (newBreed != null)
            {
                return Conflict("Breed already exists.");
            }
            #endregion

            newBreed = mapper.Map<Breed>(breedCreatedto);
            newBreed.CreatedAt = DateTime.UtcNow.AddHours(4);
            newBreed.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.AddAsync(newBreed);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion

        #region EditBreed
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditBreed(BreedCreateDTO breedEditDto,[FromRoute] int id)
        {
            #region checking NotFound
            if (!await context.Breeds.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Breed not found.");
            }

            #endregion

            #region check
            if (await context.Breeds.AnyAsync(x => x.Id != id && breedEditDto.Name == x.Name && x.IsDeleted == false))
            {
                return Conflict("Breed already exists.");
            }
            #endregion

            Breed breed = await context.Breeds.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            breed.Name = breedEditDto.Name;
            breed.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.SaveChangesAsync();

            return Ok(breed);
        }
        #endregion

        #region DeleteBreed
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            #region checking NotFound
            if (!await context.Breeds.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Breed not found.");
            }

            #endregion

            Breed breed = await context.Breeds.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            breed.IsDeleted = true;

            await context.SaveChangesAsync();
            return Ok(breed);
        }
        #endregion
    }
}
