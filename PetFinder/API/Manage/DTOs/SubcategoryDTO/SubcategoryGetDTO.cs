using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs.SubcategoryDTO
{
    public class SubcategoryGetDTO
    {
        public string Name { get; set; }
        public string categoryId { get; set; }
        public int Id { get; set; }
    }
}
