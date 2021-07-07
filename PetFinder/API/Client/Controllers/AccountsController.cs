using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetFinder.API.Client.DTOs;
using PetFinder.Data;
using PetFinder.Data.Entities;
using PetFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace PetFinder.API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtservice _jwtService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(AppDbContext context, UserManager<AppUser> userManager, IJwtservice jwtService, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
                return StatusCode(409, $"User already exists by email {registerDto.Email}");

            user = new AppUser
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                UserName = registerDto.Email

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return StatusCode(402, result.Errors.First().Description);
            }

            await _userManager.AddToRoleAsync(user, "Member");
            return StatusCode(201, user.Id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(MemberLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return NotFound();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return NotFound();



            #region JWT generate
            var roleNames = await _userManager.GetRolesAsync(user);
            string token = _jwtService.Generate(user, roleNames);
            #endregion


            return Ok(new { user.Name, user.Surname, Token = token });
        }





    }
}
