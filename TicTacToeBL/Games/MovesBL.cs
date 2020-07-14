using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeDAL.Games;
using TicTacToeEntity.Games;
using TicTacToeInterfaces.Games;

namespace TicTacToeBL.Games
{
    public class MovesBL : IMovesBL
    {
        private readonly IMovesRepository _movesRepository = new MovesRepository();

        public List<MovesInfo> GetMovesInfo(int gameId)
        {
            var movesInfo = _movesRepository.GetMovesInfo(gameId);
            var sortedMovesInfo = movesInfo.OrderBy(x => Convert.ToDateTime(x.CreationTime)).ToList();
            return sortedMovesInfo;
        }

        public void InsertMovesInfo(int gameId, MovesInfo movesInfo)
        {
            movesInfo.CreationTime = DateTime.Now.ToString();
            movesInfo.GameId = gameId;
            _movesRepository.InsertMovesInfo(movesInfo);
        }
    }
}
