using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class ColorCreateDTO
    {
        public string Name { get; set; }
    }
    public class ColorCreateDtoValidator : AbstractValidator<ColorCreateDTO>
    {
        public ColorCreateDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Length cannot be greater than 30.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
        }
    }
}
