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
                .Custom((email, context) =>
                {
                    var emailInUse = apiDbContext.Users.Any(user => user.Email == email);
                    if(emailInUse) 
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Login)
                .NotEmpty()
                .Custom((login, context) =>
                {
                    var loginInUse = apiDbContext.Users.Any(user => user.Login == login);
                    if(loginInUse)
                    {
                        context.AddFailure("Login", "That login is taken");
                    }
                });

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .Equal(x => x.ConfirmPassword);
            
        }
    }
}
