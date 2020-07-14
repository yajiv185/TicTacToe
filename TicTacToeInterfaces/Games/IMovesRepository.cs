using System.Collections.Generic;
using TicTacToeEntity.Games;

namespace TicTacToeInterfaces.Games
{
    public interface IMovesRepository
    {
        List<MovesInfo> GetMovesInfo(int gameId);
        void InsertMovesInfo(MovesInfo movesInfo);
    }
}
