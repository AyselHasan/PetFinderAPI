using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class CategoryListDTO
    {
        public List<CategoryItemDTO> Categories { get; set; }
        public int TotalCount { get; set; }
    }

    public class CategoryItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
