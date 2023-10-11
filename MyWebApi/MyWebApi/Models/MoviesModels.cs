using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public class MoviesModels
    {
        [Key]
        public int? IdMovie { get; set; }
        public string? MovieName { get; set; }
        public string? MovieGenre { get; set; }
        public int? MovieDuration { get; set; }
        public DateTime? MovieOgDate { get; set; }
        public string? MovieImage { get; set; }
        public int? MovieStatus { get; set; }

    }
}
