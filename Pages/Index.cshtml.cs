using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public TblPlayers player { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // save to database
                List<string> lst = new List<string> { player.FirstName, player.LastName, 
                    Convert.ToString(player.Id), Convert.ToString(player.Age), 
                    player.Gender, player.Password };
                
                Response.WriteAsync("<p>" + string.Join("<br>", lst) + "</p>");
            }
        }
    }
}
