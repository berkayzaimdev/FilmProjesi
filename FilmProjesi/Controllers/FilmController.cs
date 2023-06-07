using FilmProjesi.Data;
using FilmProjesi.Models;
using FilmProjesi.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmProjesi.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository _filmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FilmEkle() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult FilmEkle(string FilmAd,string FilmAciklama)
        {
            Film film = new Film { FilmAd = FilmAd, FilmAciklama = FilmAciklama};
            _filmRepository.add(film);
            return RedirectToAction("Index","Home");
        }
    }
}
