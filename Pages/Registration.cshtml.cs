using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly MyContext _context;

        public RegistrationModel(MyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblPlayers TblPlayers { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblPlayers.Add(TblPlayers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
