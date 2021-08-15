using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblGamesController : ControllerBase
    {
        private readonly MyContext _context;

        public TblGamesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/TblGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGames>>> GetTblGames()
        {
            return await _context.TblGames.ToListAsync();
        }

        // GET: api/TblGames/matrix
        [HttpGet("{matrix}")]
        public Move GetNextMove(string matrix)
        {
            List<Move> avilable_cells = new List<Move>();
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] == '0') // empty cell
                {
                    int row = i / 5, column = i % 5;
                    Move move = new Move { Row = row, Column = column };
                    avilable_cells.Add(move);
                }
            }
            // select random cell from list and return his value
            Random rand = new Random();
            int index = rand.Next(avilable_cells.Count);
            avilable_cells[index].PlayerOrServer = "Server";
            return avilable_cells[index];
        }

        // POST: api/TblGames
        [HttpPost]
        public async Task<ActionResult<TblGames>> PostTblGames(TblGames game)
        {
           _context.TblGames.Add(game);
           await _context.SaveChangesAsync();

           return CreatedAtAction("GetTblGames", new { id = game.Id }, game);          
        }
    }
}
