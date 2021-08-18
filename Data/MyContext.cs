using Microsoft.EntityFrameworkCore;
using TicTacToeServer.Model;

namespace TicTacToeServer.Data
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<TblPlayers> TblPlayers { get; set; }

        public DbSet<TblGames> TblGames { get; set; }
    }
}
