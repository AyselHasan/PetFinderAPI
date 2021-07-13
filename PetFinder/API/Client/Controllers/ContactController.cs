using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.API.Client.DTOs;
using PetFinder.Data;
using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ContactController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region CreateContact
        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateContact(ContactCreateDTO contactCreateDTO)
        {
            Contact contact = mapper.Map<Contact>(contactCreateDTO);
            contact.ModifiedAt = DateTime.UtcNow.AddHours(4);
            contact.CreatedAt = DateTime.UtcNow.AddHours(4);

            await context.Contact.AddAsync(contact);
            await context.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region GetContact
        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetContact(int id)
        {
            Contact contact = await context.Contact.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            #region checkNotFound
            if (contact == null)
            {
                return NotFound("Contact info not found.");
            }
            #endregion

            return Ok();
        }
        #endregion

        #region EditContact
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditBreed(ContactCreateDTO contactEditDto, [FromRoute] int id)
        {
            #region checking NotFound
            if (!await context.Contact.AnyAsync(x => x.Id == id && x.IsDeleted == false))
            {
                return NotFound();
            }

            #endregion

            Contact contact = await context.Contact.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            contact.Mail = contactEditDto.Mail;
            contact.Phone = contactEditDto.Phone;
            contact.ModifiedAt = DateTime.UtcNow.AddHours(4);

            await context.SaveChangesAsync();

            return Ok(contact);
            #endregion
        }
    }
}
