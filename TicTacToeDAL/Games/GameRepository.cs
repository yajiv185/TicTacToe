using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeEntity.Games;
using TicTacToeInterfaces.Games;

namespace TicTacToeDAL.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public GamesInfo GetAvailableGame()
        {
            string query = $@"select *
                              from Games
                              where User2Id is null;";
            using (var connection = new SQLiteConnection(_connString))
            {
                return connection.Query<GamesInfo>(query, new DynamicParameters(), commandType: CommandType.Text)?.FirstOrDefault();
            }
        }

        public GamesInfo GetGamesInfo(int gameId)
        {
            string query = $@"select *
                              from Games
                              where GameId = @v_gameId;";
            var dbParams = GetDbParamsFromGamesId(gameId);
            using (var connection = new SQLiteConnection(_connString))
            {
                return connection.Query<GamesInfo>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
        }

        public int? InsertGameInfo(GamesInfo gamesInfo)
        {
            int? lastInsertedId = -1;
            string query = $@"insert into Games (User1Id, User2Id, Winner, NumberOfRows)
                                          values (@v_user1Id, @v_user2Id, @v_winner, @v_numberOfRows);
                              select last_insert_rowid();";
            var dbParams = GetDbParamsFromGamesInfo(-1, gamesInfo);
            using (var connection = new SQLiteConnection(_connString))
            {
                lastInsertedId = connection.Query<int>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
            return lastInsertedId;
        }

        public bool UpdateGameInfo(int gameId, GamesInfo gamesInfo)
        {
            bool isSuccessfullyUpdated = false;
            string query = $@"update Games
                              set User1Id = ifnull(@v_user1Id, User1Id),
                                  User2Id = ifnull(@v_user2Id, User2Id),
                                  Winner = ifnull(@v_winner, Winner),
                                  NumberOfRows = ifnull(@v_numberOfRows, NumberOfRows)
                              where GameId = @v_gameId;";
            var dbParams = GetDbParamsFromGamesInfo(gameId, gamesInfo);
            using (var connection = new SQLiteConnection(_connString))
            {
                isSuccessfullyUpdated = connection.Execute(query, dbParams, commandType: CommandType.Text) > 0;
            }
            return isSuccessfullyUpdated;
        }

        private object GetDbParamsFromGamesInfo(int gameId, GamesInfo gamesInfo)
        {
            return new
            {
                v_gameId = gameId,
                v_user1Id = gamesInfo.User1Id,
                v_user2Id = gamesInfo.User2Id,
                v_winner = gamesInfo.Winner,
                v_numberOfRows = gamesInfo.NumberOfRows
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
