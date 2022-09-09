using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long user_id { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string user_surname { get; set; }

        [StringLength(15)]
        public string user_phone { get; set; }

        [StringLength(255)]
        public string user_email { get; set; }

        [StringLength(100)]
        public string user_password { get; set; }

        public DateTime user_created { get; set; }

        public bool user_isActive { get; set; }

        public bool user_confirmed { get; set; }

        [StringLength(50)]
        public string user_confirmationCode { get; set; }



        public ICollection<Building> buildManagers { get; set; }

        public ICollection<Settlement> settleManagers { get; set; }

        public ICollection<Request> userRequests { get; set; }

        public ICollection<FlatUser> flatUsers { get; set; }

        public ICollection<Session> sessions { get; set; }







    }
}