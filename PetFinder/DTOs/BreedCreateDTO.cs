using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.DTOs
{
    public class BreedCreateDTO
    {
        [StringLength(maximumLength:60)]
        public string Name { get; set; }
    }
}
