using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class FlatDto
    {
        public int flat_number { get; set; }

        [StringLength(100)]
        public string flat_desc { get; set; }
        public long build_id { get; set; }

    }
}
