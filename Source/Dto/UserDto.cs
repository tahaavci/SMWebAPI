using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class UserDto
    {

        [StringLength(50)]
        [Required]
        public string user_name { get; set; }

        [StringLength(50)]
        [Required]
        public string user_surname { get; set; }

        [StringLength(15)]
        [Required]
        public string user_phone { get; set; }

        [StringLength(255)]
        [Required]
        public string user_email { get; set; }

        [StringLength(100)]
        [Required]
        public string user_password { get; set; }





    }
}
