using FluentValidation;

namespace TicTacToeEntity.Validators
{
    public class UsersInputParamsValidator : AbstractValidator<UsersInputParams>
    {
        public UsersInputParamsValidator()
        {
            RuleFor(x => x.EmailId).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
