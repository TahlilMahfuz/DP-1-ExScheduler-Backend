using ExScheduler_Server.Dto;
using ExScheduler_Server.Interfaces;
using ExScheduler_Server.Models;
using ExScheduler_Server.Services.AdminServices;
using ExScheduler_Server.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;

namespace ExScheduler_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAdminServices _adminServices;

        public AdminController(IAuthenticationService authenticationService, IAdminServices adminServices)
        {
            _authenticationService = authenticationService;
            _adminServices = adminServices;
        }


        //AdminCotrollerStarts
        [HttpPost("adminsignup")]
        [ProducesResponseType(201, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto adminDTO)
        {
            return Ok(new { message = await _authenticationService.Signup(adminDTO) });
        }




        [HttpPost("adminlogin")]
        [ProducesResponseType(201, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Login([FromBody] AdminLoginDto adminLogindto)
        {
            return Ok(new { token = await _authenticationService.Login(adminLogindto) });
        }



        [HttpGet]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admin>))]
        public IActionResult GetAdmins()
        {
            var admins = _adminServices.GetAdmins();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(admins);
        }




        [HttpGet("{adminemail}")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAdminByEmail(string adminemail)
        {
            return Ok(new {admin = await _adminServices.GetByEmail(adminemail)});
        }




        



        //Update the CR validity
        [HttpPut("validatecr/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult ValidateCR(int id)
        {
            var message = _adminServices.ValidateCR(id);
            return Ok(new {message});
        }
    }
}
