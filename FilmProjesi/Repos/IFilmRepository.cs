using FilmProjesi.Models;

namespace FilmProjesi.Repos
{
    public interface IFilmRepository
    {
        List<Film> getAll();
        Film getById(int id);
        void add(Film film);
    }
}
