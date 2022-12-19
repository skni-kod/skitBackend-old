using FluentValidation;
using Data;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Data.Models.Validators
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator() 
        {
            RuleFor(user => user.Password)
                .MinimumLength(6);
        }
    }
}
