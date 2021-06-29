using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Models;

namespace TicTacToeServer.Pages.QueriesList
{
    public class Query3Model : PageModel
    {
        private readonly MyContext _context;

        public Query3Model(MyContext context)
        {
            _context = context;
        }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnPostAsync(string playerDetails)
        {
            string[] str = playerDetails.Split(" ");
            try {
                int id = Convert.ToInt32(str[3]);
                TblGames = await _context.TblGames.Where(g => g.PlayerId == id).ToListAsync();
            }
            catch
            {
                TblGames = new List<TblGames>();
            }
        }
    }
}
