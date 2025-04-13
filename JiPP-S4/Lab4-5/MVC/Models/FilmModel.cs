using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class FilmModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
