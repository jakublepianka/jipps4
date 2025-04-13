using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options)
        {
        }

        public DbSet<FilmModel> Films { get; set; }
    }

}
