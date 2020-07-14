using FluentValidation;
using TicTacToeEntity.Games;

namespace TicTacToeEntity.Validators
{
    public class GamesInputParamsValidator : AbstractValidator<GamesInputParams>
    {
        public GamesInputParamsValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
