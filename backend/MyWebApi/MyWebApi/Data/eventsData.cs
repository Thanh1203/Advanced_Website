using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("events")]
    public class EventsData
    {
        [Key]
        public int IdEvent { get; set; }
        public string? Eventname { get; set; }
        public string? Eventimage { get; set; }
        public string? Eventlink { get; set; }
    }
}