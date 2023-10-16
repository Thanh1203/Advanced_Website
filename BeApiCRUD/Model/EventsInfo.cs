using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("EventsInfo")]
    public class EventsInfo
    {
        [Key]
        public int? IdEvent { get; set; }
        public string? Eventname { get; set; }
        public string? Eventimage { get; set; }
        public string? Eventlink { get; set; }
    }

    public class EventsInfoFile : EventsInfo
    {
        [NotMapped]
        public IFormFile? EventImgFile { get; set; }
    }
}