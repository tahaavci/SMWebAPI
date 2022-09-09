using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{

    [ApiController]
    [Route("flat")]
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpPost("create")]
        public IActionResult Index([FromBody] FlatDto flatDto)
        {

            _flatService.CreateFlat(flatDto);


            return Ok("Flat Created Successfully");
        }
    }
}
