using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("accountUser")]
    public class AccUser
    {
        [Key]
        public int? IdUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}