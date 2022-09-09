using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long build_id { get; set; }

        [StringLength(100)]
        public string build_name { get; set; }


        public DateTime build_date { get; set; }

        [ForeignKey(nameof(buildManager))]
        public long? user_id { get; set; }
        public User? buildManager { get; set; }


        [ForeignKey(nameof(buildSettle))]
        public long settle_id { get; set; }
        public Settlement buildSettle { get; set; }



        public ICollection<Flat> buildFlats { get; set; }





    }
}
