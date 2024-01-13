using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("TicketInfor")]

    public class Ticket
    {
        [Key]
        public int? IdTicket { get; set; }
        public int? IdMovie { get; set; }
        public int? IdUser { get; set; }
        public string? SeatPosition { get; set; }
        public string? MovieDate { get; set; }

        public DateTime? Timeslot { get; set; }

    }
}