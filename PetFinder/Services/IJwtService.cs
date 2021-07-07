using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Services
{
    public interface IJwtservice
    {
        string Generate(AppUser user, IList<string> roles);
    }
}
