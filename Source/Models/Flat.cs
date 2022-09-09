using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class Flat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long flat_id { get; set; }
        public int flat_number { get; set; }

        [StringLength(100)]
        public string flat_desc { get; set; }


        [ForeignKey(nameof(flatBuildId))]
        public long build_id { get; set; }
        public Building flatBuildId { get; set; }

        public ICollection<Debt> flatDepts { get; set; }
        public ICollection<FlatUser> flatUsers { get; set; }
    }
}
