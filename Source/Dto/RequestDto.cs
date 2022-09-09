using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class RequestDto
    {

        [StringLength(100)]
        public string req_title { get; set; }

        [StringLength(5000)]
        public string req_desc { get; set; }

        public long user_id { get; set; }

        public long settle_id { get; set; }



    }
}
