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
        public string Photo { get; set; }
        public decimal AdoptionFee { get; set; }
        public string Desc { get; set; }
        public string About { get; set; }
        public Gender Gender { get; set; }
        public Age Age { get; set; }
        public Color Color { get; set; }
        public Breed Breed { get; set; }
        public Location Location { get; set; }
    }
}
