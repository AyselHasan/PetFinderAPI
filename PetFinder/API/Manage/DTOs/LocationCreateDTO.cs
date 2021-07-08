using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class LocationCreateDTO
    {
        [StringLength(maximumLength: 60)]
        public string City { get; set; }
        [StringLength(maximumLength: 60)]
        public string Region { get; set; }
    }
}
