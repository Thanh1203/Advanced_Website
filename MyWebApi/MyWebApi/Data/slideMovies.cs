using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("slideFlims")]
    public class SlideMovies
    {
        [Key]
        public int? IdSlide { get; set; }
        [Required]
        public string? SlideName { get; set; }
        public string? SlideImage { get; set; }
    }
}