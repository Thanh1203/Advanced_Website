using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("ttLichChieuPhim")]
    public class ShowTimes
    {
        [Key]
        public int IdPhim { get; set; }
        [ForeignKey("IdPhim")]
        public InfoMovies? InfoMovies { get; set; }
        [Required]

        public string? MovieDate { get; set; }
        public DateTime TimeSlot { get; set; }
        public int NofTickets { get; set; }
    }
}