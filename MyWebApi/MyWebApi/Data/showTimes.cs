using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("MovieShowtime")]
    public class ShowTimes
    {
        [Key]
        public int IdMovieShowtime { get; set; }
        [ForeignKey("IdMovie")]
        public Movies? Movies { get; set; }
        [Required]

        public string? MovieDate { get; set; }
        public DateTime TimeSlot { get; set; }
        public int NofTickets { get; set; }
    }
}