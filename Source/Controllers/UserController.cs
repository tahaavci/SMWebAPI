using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        

        [HttpPost]
        [Route("signup")]

        public IActionResult CreateUser([FromBody] UserDto newUser)
        {
            if (newUser == null || !ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_userService.CreateUser(newUser))
            {
                ModelState.AddModelError("something", "Something went wrong. ");

                return StatusCode(422, ModelState);
            }
            else

                return Ok("Successfully Created");

        }



    }
}
