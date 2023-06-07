using FilmProjesi.Data;
using FilmProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FilmProjesi.Repos;

namespace FilmProjesi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFilmRepository _filmRepository;
        private readonly IYorumRepository _yorumRepository;

        public HomeController(ILogger<HomeController> logger, Context context, IFilmRepository filmRepository, IYorumRepository yorumRepository)
            : base(context)
        {
            _logger = logger;
            _filmRepository = filmRepository;
            _yorumRepository = yorumRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FilmDetay(int id)
        {
            return View(_filmRepository.getById(id));
        }

        [Authorize]
        public IActionResult YorumEkle(string Yorum, int id, string username)
        {
            Film film = _filmRepository.getById(id);
            var yorum = new Yorum
            {
                YorumAciklama = Yorum,
                YorumTarihi = DateTime.Now,
                YorumSahibi = username,
                FilmID = id
            };
            film.FilmYorumlar.Add(yorum);
            _yorumRepository.add(yorum);
            return RedirectToAction("FilmDetay", new { id = id });
        }

        public IActionResult Yorumlarim(string username)
        {
            List<Yorum> tumYorumlar = _yorumRepository.getByUsername(username);
            Dictionary<string, List<Yorum>> filmYorumlar = new Dictionary<string, List<Yorum>>();
            foreach (var yorum in tumYorumlar)
            {
                Film film = _filmRepository.getById(yorum.FilmID);
                if (film != null && !string.IsNullOrEmpty(film.FilmAd))
                {
                    string filmName = film.FilmAd;
                    if (!filmYorumlar.ContainsKey(filmName))
                    {
                        filmYorumlar[filmName] = new List<Yorum>();
                    }
                    filmYorumlar[filmName].Add(yorum);
                }
            }
            return View(filmYorumlar);
        }

        public IActionResult YorumSil(int id)
        {
            _yorumRepository.sil(_yorumRepository.getById(id));
            return RedirectToAction("Index"); // yorumlarım kısmına geri dönmesi lazım orası ayarlanacak
        }

        public IActionResult YorumDuzenle(int id)
        {
            return View(_yorumRepository.getById(id));
        }

        public IActionResult Duzenle(int id, string NewYorum)
        {
            _yorumRepository.guncelle(id,NewYorum);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
