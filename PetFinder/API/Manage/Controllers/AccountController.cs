using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetFinder.API.Manage.DTOs;
using PetFinder.Data;
using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using PetFinder.Services;

namespace PetFinder.API.Manage.Controllers
{
    [Route("api/manage/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtservice _jwtservice;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, IJwtservice jwtservice)
        {
            _context = context;
            _userManager = userManager;
            _jwtservice = jwtservice;
        }

        #region Login
        [Route("login")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AdminLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);

            //404
            #region CheckUserNotFound
            if (user == null)
                return NotFound();
            #endregion

            //404
            #region CheckPasswordIncorrect
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return NotFound();
            #endregion

            #region JWT Generate
            var roleNames = await _userManager.GetRolesAsync(user);
            string token = _jwtservice.Generate(user, roleNames);
            #endregion

            return Ok(token);
        }

        #endregion


        [HttpGet]
        public async Task Test()
        {

            AppUser appUser = new AppUser
            {
                UserName = "SuperAdmin"
            };

            await _userManager.CreateAsync(appUser, "admin123");
            await _userManager.AddToRoleAsync(appUser, "Admin");
        }
    }
}
