using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Settlement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long settle_id { get; set; }

        [StringLength(200)]
        public string settle_name { get; set; }

        [StringLength(30)]
        public string settle_city { get; set; }

        [StringLength(100)]
        public string settle_province { get; set; }
        public DateTime settle_date { get; set; }

        [StringLength(20)]
        public string settle_phone { get; set; }

        [StringLength(100)]
        public string settle_email { get; set; }

        [StringLength(50)]
        public string settle_bankIban { get; set; }

        [StringLength(100)]
        public string settle_bankName { get; set; }


        [ForeignKey(nameof(settleManager))]
        public long user_id { get; set; }
        public User settleManager { get; set; }


        public ICollection<Building> settleBuildings { get; set; }


        public ICollection<Request> settleRequests { get; set; }


    }
}