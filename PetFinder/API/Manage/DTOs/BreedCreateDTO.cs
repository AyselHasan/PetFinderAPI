using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.DTOs
{
    public class BreedCreateDTO
    {
        public string Name { get; set; }
    }

    public class BreedCreateDtoValidator : AbstractValidator<BreedCreateDTO>
    {
        public BreedCreateDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Length cannot be greater than 50.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
        }
    }
}
