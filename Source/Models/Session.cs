using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        public string SessionToken { get; set; }


        [ForeignKey(nameof(sessionUser))]
        public long user_id { get; set; }
        public User sessionUser { get; set; }


        [StringLength(15)]
        public string ipAddress { get; set; }

        public DateTime session_expiretime { get; set; }



    }
}
