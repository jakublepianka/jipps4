using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Controllers
{
    public class FilmController : Controller
    {
        private FilmManager _manager;
        public FilmController(FilmManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var films = _manager.GetFilms();
            return View(films);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            _manager.AddFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var filmToRemove = _manager.GetFilm(id);
            return View(filmToRemove);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _manager.RemoveFilm(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var filmToEdit = _manager.GetFilm(id);
            return View(filmToEdit);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            _manager.UpdateFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var filmGetDetails = _manager.GetFilm(id);
            return View(filmGetDetails);
        }

    }
}
