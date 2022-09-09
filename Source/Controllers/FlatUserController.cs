using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{
    [ApiController]
    [Route("assign")]
    public class FlatUserController : Controller
    {
        private readonly IFlatUserService _flatUserService;

        public FlatUserController(IFlatUserService flatUserService)
        {
            _flatUserService = flatUserService;
        }

        [HttpPost("flat")]
        public IActionResult FlatAssignment([FromBody] FlatUserDto flatUsageDto)
        {

            _flatUserService.CreateRelation(flatUsageDto);


            return Ok("Relation Created.");
        }
    }
}
