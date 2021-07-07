using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly Imapper mapper;

        public LocationController(AppDbContext context, Imapper mapper)
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
        public async Task<IActionResult> CreateLocation()
        {
            return Ok();
        }
        #endregion
    }
}
