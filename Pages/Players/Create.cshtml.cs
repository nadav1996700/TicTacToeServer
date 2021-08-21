using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly MyContext _context;

        public CreateModel(MyContext context)
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

            try
            {
                _context.TblPlayers.Add(TblPlayers);
                await _context.SaveChangesAsync();
            } catch (Exception)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
