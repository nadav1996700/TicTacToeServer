using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
