using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Pet:BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public Breed Breed { get; set; }
        public string Age { get; set; }
    }
}
