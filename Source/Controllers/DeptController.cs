using Microsoft.AspNetCore.Mvc;
using SMWebApi.Dto;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Controllers
{
    [ApiController]
    [Route("dept")]
    public class DeptController : Controller
    {
        private IDebtService _debtService;

        public DeptController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpPost("create")]
        public IActionResult CreateDept([FromBody] DeptDto deptDto)
        {

            _debtService.CreateDept(deptDto);
            
            
            return Ok("Dept Created Successfully.");

        }


        [HttpPost("payment")]
        public IActionResult Payment([FromBody] long debt_id)
        {
            _debtService.PayDebt(debt_id);


            return Ok("Payment Complited.");
        }
    }
}
