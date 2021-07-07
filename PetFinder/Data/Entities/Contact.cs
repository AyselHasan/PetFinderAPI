using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Contact:BaseEntity
    {
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
