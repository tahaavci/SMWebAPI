using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{
    [Route("request")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        [HttpPost("create")]
        public IActionResult CreateRequest([FromBody] RequestDto requestDto)
        {

            _requestService.CreateRequest(requestDto);


            return Ok("Request Created.");
        }
    }
}
