using AutoMapper;
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

namespace PetFinder.API.Manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ColorController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region GetColor
        [HttpGet]
        [Route("{id}")]

        public async Task <IActionResult> GetColor(int id)
        {
            Color color = await context.Colors.FirstOrDefaultAsync(x => x.Id == id);

            if (color == null)
            {
                return NotFound();
            }
            return Ok(color.Name);

        }
        #endregion

        #region GetAllColors
        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GetAllColors()
        {
            List<Color> colors = await context.Colors.ToListAsync();
            return Ok(colors);
        }
        #endregion

        #region CreateColor
        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateColor(ColorCreateDTO colorCreateDTO)
        {
            Color newColor = await context.Colors.FirstOrDefaultAsync(x => x.Name == colorCreateDTO.Name && x.IsDeleted == false);
            #region check
            if (newColor != null)
            {
                return Conflict("Color already exists.");
            }
            #endregion

            newColor = mapper.Map<Color>(colorCreateDTO);
            newColor.CreatedAt = DateTime.UtcNow.AddHours(4);
            newColor.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.AddAsync(newColor);
            await context.SaveChangesAsync();
            return Ok();
        }
        #endregion

        #region EditColor
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditColor(ColorCreateDTO colorEditDTO, [FromRoute] int id)
        {
            #region checking NotFound
            if (!await context.Colors.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Color not found.");
            }

            #endregion

            #region check
            if (await context.Colors.AnyAsync(x => x.Id != id && colorEditDTO.Name == x.Name && x.IsDeleted == false))
            {
                return Conflict("Color already exists.");
            }
            #endregion

            Color color = await context.Colors.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            color.Name = colorEditDTO.Name;
            color.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.SaveChangesAsync();

            return Ok(color);
        }
        #endregion

        #region DeleteColor
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            #region checking NotFound
            if (!await context.Colors.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Color not found.");
            }

            #endregion

            Color color = await context.Colors.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            color.IsDeleted = true;

            await context.SaveChangesAsync();
            return Ok(color);
        }
        #endregion
    }
}
