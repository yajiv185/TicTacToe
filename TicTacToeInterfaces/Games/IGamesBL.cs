using TicTacToeEntity.Games;

namespace TicTacToeInterfaces.Games
{
    public interface IGamesBL
    {
        int? UpsertUser(int userId);
        GamesDetailInfo GetGamesInfo(int gameId);
        bool UpdateWinner(int gameId, int userId);
    }
}
