using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime IsModified { get; set; }
    }
}
