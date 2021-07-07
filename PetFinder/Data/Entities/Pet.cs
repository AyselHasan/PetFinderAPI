using PetFinder.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Pet:BaseEntity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Breed Breed { get; set; }
        public Age Age { get; set; }
    }
}
