using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
    }

    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Length cannot be greater than 50.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
        }
    }
}
