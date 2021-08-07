using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Model
{
    public class Move
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int NumberOfMove { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string PlayerOrServer { get; set; }
    }
}
