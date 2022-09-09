using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{

    [Route("session")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            this._sessionService = sessionService;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {

            if (loginDto == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string auth_token = _sessionService.CreateSession(loginDto.Email, loginDto.Password, ipAddress);

            if (auth_token.Equals(""))
                return BadRequest("Authorization Fails.");
            else
                return Ok(auth_token);
        }

        [HttpDelete("logout")]
        public IActionResult Logout([FromBody] string token)
        {
            if (token == null || !ModelState.IsValid)
                return BadRequest(ModelState);




            _sessionService.DeleteSession(token);

            return Ok("Logout Completed Succesfully");
        }













    }





   
}
