using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Model
{
    [Table("MovieShowtime")]
    public class Showtime
    {
        public int? IdMovie { get; set; }
        public string? Moviedate { get; set; }
        public DateTime? Timeslot { get; set; }
        public int? NofTickets { get; set; }
        [Key]
        public int? Row_number { get; set; }
    }
}