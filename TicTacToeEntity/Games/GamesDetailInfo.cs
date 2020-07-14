namespace TicTacToeEntity.Games
{
    public class GamesDetailInfo
    {
        public int? GameId { get; set; }
        public int? User1Id { get; set; }
        public int? User2Id { get; set; }
        public int? NumberOfRows { get; set; }
        public string Winner { get; set; }
        public string User1EmailId { get; set; }
        public string User2EmailId { get; set; }
        public string GameStatus { get; set; }
    }
}
