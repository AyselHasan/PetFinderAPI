using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Client.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(25).WithMessage("maximum uzunluq 25 ola biler!");
            RuleFor(x => x.Surname).MaximumLength(25)
                 .NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(25).WithMessage("maximum uzunluq 25 ola biler!");
            RuleFor(x => x.Email).MaximumLength(100)
                 .NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(25).WithMessage("maximum uzunluq 100 ola biler!");
            RuleFor(x => x.Password).MaximumLength(20);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("password ve confirm password eyni deyil!!");
        }
    }
}
