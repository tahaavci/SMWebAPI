using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMWebApi.Models
{
    public class FlatUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long rel_id { get; set; }


        [ForeignKey(nameof(flat))]
        public long? flat_id { get; set; }
        public Flat flat { get; set; }



        [ForeignKey(nameof(user))]
        public long? user_id { get; set; }
        public User user { get; set; }




        public bool isOwner { get; set; }


    }
}