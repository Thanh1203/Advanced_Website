using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyWebApi.Data
{
    [Table("accountUser")]
    public class AccountUsers
    {
        [Key]
        public int IdUser { get; set; }
        public string? EmailUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}