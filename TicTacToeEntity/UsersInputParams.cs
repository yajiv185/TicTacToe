using FluentValidation.Attributes;
using TicTacToeEntity.Validators;

namespace TicTacToeEntity
{
    [Validator(typeof(UsersInputParamsValidator))]
    public class UsersInputParams
    {
        public string EmailId { get; set; }
    }
}
