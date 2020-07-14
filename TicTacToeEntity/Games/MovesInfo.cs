using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEntity.Games
{
    public class MovesInfo
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        public String CreationTime { get; set; }
    }
}
