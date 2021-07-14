using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.API.Client.DTOs
{
    public class MemberLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class MemberLoginDtoValidator : AbstractValidator<MemberLoginDto>
    {
        public MemberLoginDtoValidator()
        {
            RuleFor(x => x.Email).MaximumLength(100).NotEmpty().NotNull();
            RuleFor(x => x.Password).MaximumLength(20).NotNull().NotEmpty();
        }
    }

}
