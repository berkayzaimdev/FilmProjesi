using FilmProjesi.Data;
using FilmProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProjesi.Repos
{
    public class FilmRepository : IFilmRepository
    {
        private Context _context;
        public FilmRepository(Context context)
        {
            _context = context;
        }
        public List<Film> getAll() => _context.Filmler.ToList();
        public Film getById(int id) => _context.Filmler.Include(f => f.FilmYorumlar).FirstOrDefault(f => f.FilmID == id);
        public void add(Film film) 
        {
            _context.Filmler.Add(film);
            _context.SaveChanges();
        }
    }
}
