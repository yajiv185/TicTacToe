using FluentValidation;
using TicTacToeEntity.Games;

namespace TicTacToeEntity.Validators
{
    public class MovesInfoValidator : AbstractValidator<MovesInfo>
    {
        public MovesInfoValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.ColNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.RowNumber).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GameId).GreaterThan(0);
        }
    }
}
