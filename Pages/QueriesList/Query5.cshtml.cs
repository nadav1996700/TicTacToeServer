using System;
using System.Collections;
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
    public class Query5Model : PageModel
    {
        private readonly MyContext _context;

        public Query5Model(MyContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }

        public Dictionary<int, List<TblPlayers>> Groups { get; set; }

        public async Task OnGetAsync()
        {
            List<TblGames> tblGames = await _context.TblGames.ToListAsync();
            TblPlayers = await _context.TblPlayers.ToListAsync();
            // max count of games that one player played
            int max = (from p in TblPlayers
                       let count = tblGames.Count(g => g.PlayerId == p.Id)
                       orderby count descending
                       select count).First();
            Groups = new Dictionary<int, List<TblPlayers>>();

            for (int i = max; i >= 0; i--)
            {
                List<TblPlayers> players =
                    (from p in TblPlayers
                    where tblGames.Count(g => g.PlayerId == p.Id) == i
                    select p).ToList();
                Groups.Add(i, players);
            }

            // code for display the results without gap of empty games
            //Groups = (from p in TblPlayers
            //         let count = tblGames.Count(g => g.PlayerId == p.Id)
            //         orderby count descending
            //         group p by count into g
            //         select g)
            //        .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
