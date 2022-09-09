using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Request
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long req_id { get; set; }

        [StringLength(100)]
        public string req_title { get; set; }

        [StringLength(5000)]
        public string req_desc { get; set; }
        public DateTime req_date { get; set; }
        public bool req_isCompleted { get; set; }


        [ForeignKey(nameof(req_srcUser))]
        public long? user_id { get; set; }
        public User req_srcUser { get; set; }


        [ForeignKey(nameof(req_dstSettle))]
        public long? settle_id { get; set; }
        public Settlement req_dstSettle { get; set; }





    }
}