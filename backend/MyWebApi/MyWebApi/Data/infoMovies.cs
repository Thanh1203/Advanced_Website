using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Data
{
    [Table("ttPhim")]
    public class InfoMovies
    {
        [Key]
        public int IdPhim { get; set; }
        [Required]
        public string? TenPhim { get; set; }
        public string? TheLoai { get; set; }
        public int ThoiLuong { get; set; }
        public DateTime KhoiChieu { get; set; }
        public string? ImgName { get; set; }
        public int StatusFlim { get; set; }
    }
}
