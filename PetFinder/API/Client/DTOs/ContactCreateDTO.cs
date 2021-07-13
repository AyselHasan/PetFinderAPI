using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Client.DTOs
{
    public class ContactCreateDTO
    {
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
    public class ContactCreateDTOValidator : AbstractValidator<ContactCreateDTO>
    {
        public ContactCreateDTOValidator()
        {
            RuleFor(x => x.Phone).MaximumLength(100).WithMessage("Length cannot be greater than 100.")
               .NotEmpty().NotNull().WithMessage("Cannot be empty!");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Length cannot be greater than 100.")
              .NotEmpty().NotNull().WithMessage("Cannot be empty!");
        }
    }
}
