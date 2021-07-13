using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Manage.DTOs
{
    public class LocationCreateDTO
    {
        public string City { get; set; }
        public string Region { get; set; }
    }
    public class LocationCreateDtoValidator : AbstractValidator<LocationCreateDTO>
    {
        public LocationCreateDtoValidator()
        {
            RuleFor(x => x.City).MaximumLength(60).WithMessage("Length cannot be greater than 60.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
            RuleFor(x => x.Region).MaximumLength(60).WithMessage("Length cannot be greater than 60.")
                .NotEmpty().NotNull().WithMessage("Cannot be empty.");
        }
    }
}
