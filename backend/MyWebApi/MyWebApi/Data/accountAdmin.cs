using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("accountAdmin")]
    public class accountAdmin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Taikhoan { get; set; }

        public string? Matkhau { get; set; }
    }
}
