using TicTacToeEntity.Games;

namespace TicTacToeInterfaces.Games
{
    public interface IGameRepository
    {
        GamesInfo GetAvailableGame();
        GamesInfo GetGamesInfo(int gameId);
        int? InsertGameInfo(GamesInfo gamesInfo);
        bool UpdateGameInfo(int gameId, GamesInfo gamesInfo);
    }
}
