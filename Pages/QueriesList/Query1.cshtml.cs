using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Pages.QueriesList
{
    public class Query1Model : PageModel
    {
        private readonly MyContext _context;

        public Query1Model(MyContext context)
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
