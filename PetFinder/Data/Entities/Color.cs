using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
