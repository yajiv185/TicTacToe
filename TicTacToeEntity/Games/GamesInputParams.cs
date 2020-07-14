using FluentValidation.Attributes;
using TicTacToeEntity.Validators;

namespace TicTacToeEntity.Games
{
    [Validator(typeof(GamesInputParamsValidator))]
    public class GamesInputParams
    {
        public int UserId { get; set; }
    }
}
