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
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CategoryController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region CreateCategory
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            #region CheckCategoryExist
            if (await context.Categories.AnyAsync(x => x.Name.ToLower() == categoryCreateDTO.Name.Trim().ToLower()))
            {
                return Conflict($"Category already exist by name: {categoryCreateDTO.Name}");
            }
            #endregion

            Category category = mapper.Map<Category>(categoryCreateDTO);
            category.CreatedAt = DateTime.UtcNow.AddHours(4);
            category.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return StatusCode(201, category.Id);
        }
        #endregion

        #region GetCategory
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            #region checking NotFound
            if (category == null)
            {
                return NotFound("Category not found.");
            }
               
            #endregion

            CategoryGetDTO categoryGetDTO = mapper.Map<CategoryGetDTO>(category);

            return Ok(categoryGetDTO);
        }
        #endregion

        #region GetAllCategories
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            List<Category> categories = await context.Categories.OrderByDescending(n => n.Name).Skip((page - 1) * 8).Take(8).ToListAsync();

            CategoryListDTO categoriesDto = new CategoryListDTO
            {
                Categories = mapper.Map<List<CategoryItemDTO>>(categories),
                TotalCount = await context.Categories.Where(x => !x.IsDeleted).CountAsync()
            };

            return Ok(categoriesDto);
        }
        #endregion

        #region EditCategory
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditCategory(CategoryCreateDTO categoryEditDTO, int id)
        {
            #region checking NotFound
            if (!await context.Categories.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound("Category not found.");
            }

            #endregion

            #region check
            if (await context.Categories.AnyAsync(x => x.Id != id && categoryEditDTO.Name == x.Name && x.IsDeleted == false))
            {
                return Conflict("Category already exists.");
            }
            #endregion

            Category category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            category.Name = categoryEditDTO.Name;
            category.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.SaveChangesAsync();

            return Ok(categoryEditDTO);
        }
        #endregion

        #region DeleteCategory
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            #region check NotFound
            if (category == null)
            {
                return NotFound();
            }
            #endregion
            category.IsDeleted = true;
            await context.SaveChangesAsync();

            return Ok(category);
        }
        #endregion

    }
}
