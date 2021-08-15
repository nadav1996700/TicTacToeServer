using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Data;
using TicTacToeServer.Model;

namespace TicTacToeServer.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPlayersController : ControllerBase
    {
        private readonly MyContext _context;

        public TblPlayersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/TblPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPlayers>> GetTblPlayers(int id)
        {
            var player = await _context.TblPlayers.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        //api/TblPlayers/{id}/{password}
        [HttpGet("{id}/{password}")]
        public async Task<ActionResult<TblPlayers>> GetPlayer(string id, string password)
        {
            var tblPlayers = await _context.TblPlayers.ToListAsync();

            if (tblPlayers == null)
                return NotFound();

            var player = tblPlayers.Where(p => p.Id.Trim() == id && p.Password.Trim() == password).FirstOrDefault();
            if (player != null) 
                return player; 
            else 
                return NotFound();
        }

        // PUT: api/TblPlayers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPlayers(string id, TblPlayers tblPlayers)
        {
            if (id != tblPlayers.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPlayers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblPlayers
        [HttpPost]
        public async Task<ActionResult<TblPlayers>> PostTblPlayers(TblPlayers tblPlayers)
        {
            _context.TblPlayers.Add(tblPlayers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlayers", new { id = tblPlayers.Id }, tblPlayers);
        }

        // DELETE: api/TblPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPlayers>> DeleteTblPlayers(int id)
        {
            var tblPlayers = await _context.TblPlayers.FindAsync(id);
            if (tblPlayers == null)
            {
                return NotFound();
            }

            _context.TblPlayers.Remove(tblPlayers);
            await _context.SaveChangesAsync();

            return tblPlayers;
        }

        private bool TblPlayersExists(string id)
        {
            return _context.TblPlayers.Any(e => e.Id == id);
        }
    }
}
