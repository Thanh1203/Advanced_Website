using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("SlideMovie")]
    public class SlideMovie
    {
        [Key]
        public int? IdSlide { get; set; }
        public string? SlideName { get; set; }
        public string? SlideImage { get; set; }
    }

    public class SlideMovieFile : SlideMovie
    {
        [NotMapped]
        public IFormFile? SlideImgFile { get; set; }
    }
}