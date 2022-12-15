using Data;
using FluentValidation;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Data.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ApiDbContext apiDbContext) 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = apiDbContext.Users.Any(user => user.Email == value);
                    if(emailInUse) 
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .Equal(x => x.ConfirmPassword);
            
        }
    }
}
