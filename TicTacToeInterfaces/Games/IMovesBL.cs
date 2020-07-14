using System.Collections.Generic;
using TicTacToeEntity.Games;

namespace TicTacToeInterfaces.Games
{
    public interface IMovesBL
    {
        List<MovesInfo> GetMovesInfo(int gameId);
        void InsertMovesInfo(int gameId, MovesInfo movesInfo);
    }
}
