using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class ProfileSlider:BaseEntity
    {
        public int Order { get; set; }
        public string Photo { get; set; }
    }
}
