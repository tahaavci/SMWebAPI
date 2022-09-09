using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{

    [Route("settlement")]
    [ApiController]
    public class SettlementController : Controller
    {
        private readonly ISettlementService _settlementService;

        public SettlementController(ISettlementService settlementService)
        {
            _settlementService = settlementService;
        }

        [HttpPost("create")]
        public IActionResult CreateSettlement([FromBody] SettlementDto settle)
        {
            if (settle == null || !ModelState.IsValid)
                return BadRequest(ModelState);
          

            _settlementService.CreateSettlement(settle);



            return Ok("Settlement Created Successfully");
        }
    }
}
