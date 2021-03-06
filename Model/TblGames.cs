using System;
using System.ComponentModel.DataAnnotations;

namespace TicTacToeServer.Model
{
    public class TblGames
    {
        [Required(ErrorMessage = "game id is required")]
        [Display(Name = "Game Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "player id is missing")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "player id must contain 9 digits")]
        public string PlayerId { get; set; }

        [Required(ErrorMessage = "enter the date and time of the game")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "please enter the winner of the game or draw")]
        public string Winner { get; set; }

        [Required(ErrorMessage = "player shape is missing")]
        public string PlayerShape { get; set; }

        [Required(ErrorMessage = "server shape is missing")]
        public string ServerShape { get; set; }
        [Required(ErrorMessage = "player color is missing")]
        public string PlayerColor { get; set; }
        [Required(ErrorMessage = "server color is missing")]
        public string ServerColor { get; set; }

        [Required(ErrorMessage = "number of moves is missing")]
        [Range(5,25)]
        public int NumberOfMoves { get; set; }
    }
}
