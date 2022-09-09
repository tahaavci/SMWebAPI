using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class DeptDto
    {

        public long dept_amount { get; set; }
        public DateTime dept_duedate { get; set; }

        public string dept_type { get; set; }

        public long flat_id { get; set; }

        public string manager_token { get; set; }

    }
}
