using TicTacToeDAL.Games;
using TicTacToeDAL.Users;
using TicTacToeEntity.Games;
using TicTacToeEntity.Users;
using TicTacToeInterfaces.Games;
using TicTacToeInterfaces.Users;

namespace TicTacToeBL.Games
{
    public class GamesBL : IGamesBL
    {
        private readonly IGameRepository _gamesRepository = new GameRepository();
        private readonly IUsersRepository _usersRepository = new UsersRepository();

        /// <summary>
        /// It will fetch games info based on gameId.
        /// </summary>
        /// <param name="gameId">UniqueId of game</param>
        /// <returns>Details inforamation about game</returns>
        public GamesDetailInfo GetGamesInfo(int gameId)
        {
            GamesInfo gamesInfo = _gamesRepository.GetGamesInfo(gameId);
            return GetGamesDetailInfo(gamesInfo);
        }

        /// <summary>
        /// It will insert new game if no game is available or updapte user in game
        /// </summary>
        /// <param name="userId">Uniqie id of user</param>
        /// <returns>GameId: Usinque id of game</returns>
        public int? UpsertUser(int userId)
        {
            int? gameId = -1;
            GamesInfo gamesInfo = _gamesRepository.GetAvailableGame();
            if(gamesInfo == null || gamesInfo.GameId <= 0)
            {
                GamesInfo newGameInfo = new GamesInfo()
                {
                    User1Id = userId,
                    NumberOfRows = 3
                };
                gameId = _gamesRepository.InsertGameInfo(newGameInfo);
            }
            else
            {
                gamesInfo.User2Id = userId;
                bool isSuccess = _gamesRepository.UpdateGameInfo((int)gamesInfo.GameId, gamesInfo);
                if(isSuccess)
                {
                    gameId = gamesInfo.GameId;
                }
            }
            return gameId;
        }

        /// <summary>
        /// It will update the winner for perticular game
        /// </summary>
        /// <param name="gameId">Unique id of game</param>
        /// <param name="userId">Unique id of user</param>
        /// <returns>Boolean indicating success/failure</returns>
        public bool UpdateWinner(int gameId, int userId)
        {
            GamesInfo gamesInfo = new GamesInfo
            {
                Winner = userId
            };
            bool isSuccess = _gamesRepository.UpdateGameInfo(gameId, gamesInfo);
            return isSuccess;
        }

        private GamesDetailInfo GetGamesDetailInfo(GamesInfo gamesInfo)
        {
            GamesDetailInfo gamesDetailInfo = new GamesDetailInfo();
            if (gamesInfo != null)
            {
                gamesDetailInfo.GameId = gamesInfo.GameId;
                gamesDetailInfo.NumberOfRows = gamesInfo.NumberOfRows;
                UsersInfo user1Info = _usersRepository.GetUsersInfo((int)gamesInfo.User1Id);
                gamesDetailInfo.User1Id = gamesInfo.User1Id;
                gamesDetailInfo.User1EmailId = user1Info.EmailId;
                if (gamesInfo.User2Id != null && gamesInfo.User2Id > 0)
                {
                    UsersInfo user2Info = _usersRepository.GetUsersInfo((int)gamesInfo.User2Id);
                    gamesDetailInfo.User2Id = gamesInfo.User2Id;
                    gamesDetailInfo.User2EmailId = user2Info.EmailId;
                }
                gamesDetailInfo.GameStatus = GetGameStatus(gamesInfo);

            }
            return gamesDetailInfo;
        }

        private string GetGameStatus(GamesInfo gamesInfo)
        {
            if (gamesInfo.Winner != null)
            {
                return "Completed";
            }
            else
            {
                return gamesInfo.User2Id != null ? "In Progress" : "Waiting for Player";
            }
        }
    }
}
