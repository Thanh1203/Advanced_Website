using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeApiCRUD.Model
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int? IdUser { get; set; }
        public string? UserFullName { get; set; }
        public string? UserSex { get; set; }
        public DateTime? UserBirth { get; set; }
        public string? UserPhonenumber { get; set; }
        public string? UserCity { get; set; }
        public string? UserDistrict { get; set; }
        public string? UserLocation { get; set; }
        public string? UserEmail { get; set; }
    }
}