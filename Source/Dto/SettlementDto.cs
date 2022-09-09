using SMWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class SettlementDto
    {
        [StringLength(200)]
        public string settle_name { get; set; }

        [StringLength(30)]
        public string settle_city { get; set; }

        [StringLength(100)]
        public string settle_province { get; set; }

        [StringLength(20)]
        public string settle_phone { get; set; }

        [StringLength(100)]
        public string settle_email { get; set; }

        [StringLength(50)]
        public string settle_bankIban { get; set; }

        [StringLength(100)]
        public string settle_bankName { get; set; }

        public string settleManagerEmail { get; set; }


    }
}
