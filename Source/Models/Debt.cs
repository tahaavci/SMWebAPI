using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Debt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long debt_id { get; set; }
        public long debt_amount { get; set; }
        public DateTime debt_duedate { get; set; }
        public bool debt_iscompleted { get; set; }

        [StringLength(100)]
        public string debt_type { get; set; }


        public Flat? debtFlatId { get; set; }
    }
}
