using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class ColorCreateDTO
    {
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }
    }
}
