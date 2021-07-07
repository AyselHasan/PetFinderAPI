using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Location:BaseEntity
    {
        public string Region { get; set; }
        public string City { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
