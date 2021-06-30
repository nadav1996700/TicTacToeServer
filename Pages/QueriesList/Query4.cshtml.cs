using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Pages.QueriesList
{
    public class Query4Model : PageModel
    {
        private readonly MyContext _context;

        public Query4Model(MyContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }

        public IList<TblGames> TblGames { get; set; }

        public List<int> CountList { get; set; }

        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();
            TblPlayers = await _context.TblPlayers.ToListAsync();
            CountList = new List<int>();
            foreach(var player in TblPlayers)
            {
                int games = TblGames.Where(g => g.PlayerId == player.Id).Count();
                CountList.Add(games);
            }
        }
    }
}
