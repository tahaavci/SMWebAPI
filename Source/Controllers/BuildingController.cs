using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{
    [ApiController]
    [Route("building")]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost("create")]
        public IActionResult CreateBuilding([FromBody] BuildingDto buildingDto)
        {
            if (buildingDto == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            _buildingService.CreateBuilding(buildingDto);



            return Ok("Building Created Successfully");
        }




        [HttpGet("GetAllBuildings")]
        public IActionResult GetBuilding()
        {
            var buildings = _buildingService.GetBuildings();

            return Ok(buildings);
        }




        [HttpPost("GetBuildingsBySettleEmail")]
        public IActionResult GetBuildingsBySettle([FromBody] string settle_email)
        {
            var buildings = _buildingService.GetBuildingsBySettle(settle_email);

            return Ok(buildings);
        }







    }
}
