namespace VerticalSliceArchitecture.Data
{
    using Domain;
    using Games.Models;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<GameConsole> Consoles { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
