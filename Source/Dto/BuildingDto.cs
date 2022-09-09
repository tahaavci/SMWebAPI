using System.ComponentModel.DataAnnotations;

namespace SMWebApi.Dto
{
    public class BuildingDto
    {
        [StringLength(100)]
        public string build_name { get; set; }

        public string build_settleEmail { get; set; }

        [StringLength(255)]
        public string? build_managerEmail { get; set; }



    }
}
