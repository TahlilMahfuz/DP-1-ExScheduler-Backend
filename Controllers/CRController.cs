using ExScheduler_Server.Dto;
using ExScheduler_Server.Models;
using ExScheduler_Server.Services.AdminServices;
using ExScheduler_Server.Services.ClassRepresentativeAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace ExScheduler_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRController : Controller
    {
        private readonly IStudentAuthenticationService _CRAuthentication;

        public CRController(IStudentAuthenticationService cRAuthentication)
        {
            _CRAuthentication = cRAuthentication;
        }

        [HttpPost("CRSignup")]
        [ProducesResponseType(201, Type = typeof(Students))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateCR([FromBody] StudentDto CRDto)
        {
            return Ok(new { message = await _CRAuthentication.Signup(CRDto) });
        }

        [HttpPost("CRLogin")]
        [ProducesResponseType(201, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Login([FromBody] StudentLoginDto cRLoginDto)
        {
            return Ok(new { message = await _CRAuthentication.Login(cRLoginDto) });
        }
    }
}
