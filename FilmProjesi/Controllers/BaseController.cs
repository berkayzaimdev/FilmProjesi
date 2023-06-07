using FilmProjesi.Data;
using FilmProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmProjesi.Controllers
{
    public class BaseController : Controller
    {
        protected readonly Context _Context;

        public BaseController(Context context)
        {
            _Context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var filmViewModel = new FilmViewModel();
            filmViewModel.Filmler = _Context.Filmler.ToList();
            ViewBag.FilmViewModel = filmViewModel;
            base.OnActionExecuting(context);
        }
    }
}
