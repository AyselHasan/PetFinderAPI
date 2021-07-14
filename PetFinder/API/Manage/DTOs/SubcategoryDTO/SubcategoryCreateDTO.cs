using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs.SubcategoryDTO
{
    public class SubcategoryCreateDTO
    {
        public string Name { get; set; }
        public string categoryId { get; set; }
    }
    public class SubcategoryCreateDtoValidator : AbstractValidator<SubcategoryCreateDTO>
    {
        public SubcategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Length cannot be greater than 50.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
        }
    }
}
