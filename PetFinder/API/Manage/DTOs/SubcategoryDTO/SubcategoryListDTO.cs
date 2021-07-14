using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs.SubcategoryDTO
{
    public class SubcategoryListDTO
    {
        public List<SubcategoryItemDTO> Subcategories { get; set; }
        public int TotalCount { get; set; }
    }

    public class SubcategoryItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
