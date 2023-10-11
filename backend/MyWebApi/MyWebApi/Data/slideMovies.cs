using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("slideFlims")]
    public class SlideMovies
    {
        [Key]
        public int? IdSlide { get; set; }
        public string? slideName { get; set; }
        public string? slideImage { get; set; }
    }
}