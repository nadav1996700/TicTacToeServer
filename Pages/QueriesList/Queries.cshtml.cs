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
    public class QueriesModel : PageModel
    {
        private readonly MyContext _context;

        public QueriesModel(MyContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get;set; }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
        }

        public async Task OnPostAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
        }
    }
}
