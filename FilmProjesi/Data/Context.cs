using FilmProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProjesi.Data
{
    public class Context : DbContext
    {
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
