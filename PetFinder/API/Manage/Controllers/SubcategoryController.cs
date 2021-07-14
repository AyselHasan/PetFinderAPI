using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.API.Manage.DTOs;
using PetFinder.API.Manage.DTOs.SubcategoryDTO;
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
    public class SubcategoryController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public SubcategoryController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Create subcategory
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSubcategory(SubcategoryCreateDTO createDTO)
        {
            #region CheckCategoryExist
            if (await context.Categories.AnyAsync(x => x.Name.ToLower() == createDTO.Name.Trim().ToLower()))
            {
                return Conflict($"Category already exist by name: {createDTO.Name}");
            }
            #endregion

            Subcategory subcategory = mapper.Map<Subcategory>(createDTO);
            subcategory.CreatedAt = DateTime.UtcNow.AddHours(4);
            subcategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.Subcategories.AddAsync(subcategory);
            await context.SaveChangesAsync();

            return StatusCode(201, subcategory.Id);
        }
        #endregion

        #region Get subcategory
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSubcategory(int id)
        {

            Subcategory subcategory = await context.Subcategories.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            #region checking NotFound
            if (subcategory == null)
            {
                return NotFound("Subcategory not found.");
            }

            #endregion

            SubcategoryGetDTO getDTO = mapper.Map<SubcategoryGetDTO>(subcategory);

            return Ok(getDTO);
        }
        #endregion

        #region Get All Subcategories
        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GetAllSubcategories(int page = 1)
        {
            List<Subcategory> subcategories = await context.Subcategories.OrderByDescending(n => n.Name).Skip((page - 1) * 8).Take(8).ToListAsync();

            SubcategoryListDTO subcategoriesDTO = new SubcategoryListDTO
            {
                Subcategories = mapper.Map<List<SubcategoryItemDTO>>(subcategories),
                TotalCount = await context.Subcategories.Where(x => !x.IsDeleted).CountAsync()
            };

            return Ok(subcategoriesDTO);
        }
        #endregion

        #region Edit Subcategory
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditSubcategory(CategoryCreateDTO editDTO, int id)
        {
            #region checking NotFound
            if (!await context.Subcategories.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Subcategory not found.");
            }

            #endregion

            #region check
            if (await context.Subcategories.AnyAsync(x => x.Id != id && editDTO.Name == x.Name && x.IsDeleted == false))
            {
                return Conflict("Subcategory already exists.");
            }
            #endregion

            Subcategory subcategory = await context.Subcategories.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            subcategory.Name = editDTO.Name;
            subcategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.SaveChangesAsync();

            return Ok(editDTO);
        }
        #endregion

        #region Delete Subcategory
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            Subcategory subcategory = await context.Subcategories.FirstOrDefaultAsync(x => x.Id == id);

            #region check NotFound
            if (subcategory == null)
            {
                return NotFound();
            }
            #endregion
            subcategory.IsDeleted = true;
            await context.SaveChangesAsync();

            return Ok(subcategory);
        }
        #endregion
    }
}
