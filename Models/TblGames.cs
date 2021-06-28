using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Models
{
    public class TblGames
    {
        [Required(ErrorMessage = "game id is required")]
        [Display(Name = "Game Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "player id is missing")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "enter the date and time of the game")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "please enter the winner of the game or draw")]
        public string Winner { get; set; }

        [Required(ErrorMessage = "player shape is missing")]
        public string PlayerShape { get; set; }

        [Required(ErrorMessage = "server shape is missing")]
        public string ServerShape { get; set; }

        [Required(ErrorMessage = "number of moves is missing")]
        [Range(5,25)]
        public int NumberOfMoves { get; set; }
    }
}
