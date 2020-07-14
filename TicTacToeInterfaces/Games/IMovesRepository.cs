using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeEntity.Games;

namespace TicTacToeInterfaces.Games
{
    public interface IMovesRepository
    {
        List<MovesInfo> GetMovesInfo(int gameId);
        void InsertMovesInfo(MovesInfo movesInfo);
    }
}
