using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServer.Model
{
    public class TblPlayers
    {
        [Required(ErrorMessage = "first name must be entered")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name length can't be less than 2")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "last name must be entered")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name length can't be less than 2")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Id must be entered")]
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter your age")]
        [Range(5,99, ErrorMessage = "Age must be between 5-99")]
        public int Age { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Password must be entered")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Password must contain at list 4 chracters")]
        public string Password { get; set; }
    }
}
