using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeDAL.Games;
using TicTacToeEntity.Games;
using TicTacToeInterfaces.Games;

namespace TicTacToeBL.Games
{
    public class MovesBL : IMovesBL
    {
        private readonly IMovesRepository _movesRepository = new MovesRepository();

        /// <summary>
        /// It will provides list of moves sorted based on creation time of it based on gameId provied
        /// </summary>
        /// <param name="gameId">Unique id of game</param>
        /// <returns>List of moves</returns>
        public List<MovesInfo> GetMovesInfo(int gameId)
        {
            var movesInfo = _movesRepository.GetMovesInfo(gameId);
            var sortedMovesInfo = movesInfo.OrderBy(x => Convert.ToDateTime(x.CreationTime)).ToList();
            return sortedMovesInfo;
        }

        /// <summary>
        /// It simpley insert's move of user in db
        /// </summary>
        /// <param name="gameId">Unique id of game</param>
        /// <param name="movesInfo">Moves info like colNumber, rowNumber and etc.</param>
        public void InsertMovesInfo(int gameId, MovesInfo movesInfo)
        {
            movesInfo.CreationTime = DateTime.Now.ToString();
            movesInfo.GameId = gameId;
            _movesRepository.InsertMovesInfo(movesInfo);
        }
    }
}
