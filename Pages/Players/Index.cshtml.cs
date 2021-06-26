using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Models;

namespace TicTacToeServer.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly MyContext _context;

        public IndexModel(MyContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get;set; }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
        }
    }
}
