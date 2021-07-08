using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.API.Manage.DTOs;
using PetFinder.Data;
using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PetFinder.API.Manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public LocationController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Get Location
        [Route("{id}")]
        [HttpGet]
        
        public async Task<IActionResult> GetLocation(int id)
        {
            Location location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        #endregion

        #region GetAllLocations
        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GetAllLocations()
        {
            List<Location> Locations = await context.Locations.ToListAsync();
            return Ok(Locations);
        }
        #endregion

        #region CreateLocation
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateLocation(LocationCreateDTO locationCreateDTO)
        {
            Location newLocation = await context.Locations.FirstOrDefaultAsync(x => x.City == locationCreateDTO.City &&x.Region==locationCreateDTO.Region && x.IsDeleted == false);

            #region check
            if (newLocation != null)
            {
                return Conflict("Location already exists.");
            }
            #endregion
            newLocation = mapper.Map<Location>(locationCreateDTO);
            newLocation.CreatedAt = DateTime.UtcNow;
            newLocation.ModifiedAt = DateTime.UtcNow;

            await context.AddAsync(newLocation);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion

        #region EditLocation
        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> EditLocation (LocationCreateDTO locationEditDto, int id)
        {
            #region checking NotFound
            if (!await context.Locations.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Location not found.");
            }

            #endregion

            #region check
            if (await context.Locations.AnyAsync(x => x.Id != id && locationEditDto.City == x.City && x.Region==locationEditDto.Region && x.IsDeleted == false))
            {
                return Conflict("Location already exists.");
            }
            #endregion

            Location location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            location.City = locationEditDto.City;
            location.Region = locationEditDto.Region;
            location.ModifiedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return Ok(location);
        }
        #endregion

        #region DeleteLocation
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            #region checking NotFound
            if (!await context.Locations.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Location not found.");
            }

            #endregion

            Location location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            location.IsDeleted = true;

            await context.SaveChangesAsync();
            return Ok(location);
        }
        #endregion
    }
}
