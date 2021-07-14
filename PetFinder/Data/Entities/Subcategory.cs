using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Entities
{
    public class Subcategory:BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
