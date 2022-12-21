using Data;
using FluentValidation;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Data.Models.Validators
{
    public class EditUserDtoValidator : AbstractValidator<EditUserDto>
    {
        public EditUserDtoValidator(ApiDbContext apiDbContext)
        {
            RuleFor(editUser => editUser.Email)
                .EmailAddress()
                .Custom((email, context) =>
                {
                    var emailInUse = apiDbContext.Users.Any(user => user.Email == email);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
