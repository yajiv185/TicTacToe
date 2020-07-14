using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEntity.Games
{
    public class GamesInfo
    {
        public int? GameId { get; set; }
        public int? User1Id { get; set; }
        public int? User2Id { get; set; }
        public int? Winner { get; set; }
        public int? NumberOfRows { get; set; }
    }
}
