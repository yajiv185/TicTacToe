using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using TicTacToeEntity.Games;
using TicTacToeInterfaces.Games;

namespace TicTacToeDAL.Games
{
    public class MovesRepository : IMovesRepository
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        /// <summary>
        /// Fteches all the moves of perticular game
        /// </summary>
        /// <param name="gameId">Unique id of game</param>
        /// <returns>List of moves plyed in that game</returns>
        public List<MovesInfo> GetMovesInfo(int gameId)
        {
            string query = $@"select *
                              from Moves
                              where GameId = @v_gameId;";
            var dbParams = GetDbParamsFromGamesId(gameId);
            using (var connection = new SQLiteConnection(_connString))
            {
                return connection.Query<MovesInfo>(query, dbParams, commandType: CommandType.Text)?.ToList();
            }
        }

        /// <summary>
        /// Insert moves info into Moves table of DB.
        /// </summary>
        /// <param name="movesInfo">Move related info like rolNumber, colNumber, etc</param>
        public void InsertMovesInfo(MovesInfo movesInfo)
        {
            string query = $@"insert into Moves (GameId, UserId, RowNumber, ColNumber, CreationTime)
                                          values (@v_gameId, @v_userId, @v_rowNumber, @v_colNumber, @v_creationTime);";
            var dbParams = GetDbParamsFromMovesInfo(movesInfo);
            using (var connection = new SQLiteConnection(_connString))
            {
                connection.Execute(query, dbParams, commandType: CommandType.Text);
            }
        }

        private object GetDbParamsFromMovesInfo(MovesInfo movesInfo)
        {
            return new
            {
                v_gameId = movesInfo.GameId,
                v_userId = movesInfo.UserId,
                v_rowNumber = movesInfo.RowNumber,
                v_colNumber = movesInfo.ColNumber,
                v_creationTime = movesInfo.CreationTime
            };
        }

        private object GetDbParamsFromGamesId(int gameId)
        {
            return new
            {
                v_gameId = gameId
            };
        }
    }
}
