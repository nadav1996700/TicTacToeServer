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
    public class Query23Model : PageModel
    {
        private readonly MyContext _context;

        public Query23Model(MyContext context)
        {
            _context = context;
        }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();
        }

        public async Task OnPostQueryThreeAsync(string playerDetails)
        {
            string[] str = playerDetails.Split(" ");
            try
            {
                string id = str[3];
                TblGames = await _context.TblGames.Where(g => g.PlayerId == id).ToListAsync();
            }
            catch
            {
                TblGames = new List<TblGames>();
            }
        }
    }
}
