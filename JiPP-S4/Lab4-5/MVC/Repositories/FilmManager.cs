using MVC.Data;
using MVC.Models;

namespace MVC.Repositories
{
    public class FilmManager
    {
        private FilmContext _context;
        public FilmManager(FilmContext context)
        {
            _context = context;
        }
        public FilmManager AddFilm(FilmModel filmModel)
        {
            _context.Films.Add(filmModel);
            _context.SaveChanges();
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var filmToDelete = GetFilm(id);
            if (filmToDelete != null)
            {
                _context.Films.Remove(filmToDelete);
                _context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            _context.Films.Update(filmModel);
            _context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            var film = _context.Films.SingleOrDefault(x => x.ID == id);
            return film;
        }

        public List<FilmModel> GetFilms()
        {
            var films = _context.Films.ToList();
            return films;
        }

 
    }
}