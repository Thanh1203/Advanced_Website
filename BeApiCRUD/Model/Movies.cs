using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("MovieInfo")]
    public class Movies
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

    public class MoviesFile : Movies
    {
        [NotMapped]
        public IFormFile? MovieImgfile { get; set; }
    }
}
