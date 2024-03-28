using ExScheduler_Server.Data;
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
        private readonly DataContext _context;

        public AdminController(IAuthenticationService authenticationService, IAdminServices adminServices,DataContext _context)
        {
            _authenticationService = authenticationService;
            _adminServices = adminServices;
            this._context = _context;
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
            try
            {
                string token = await _authenticationService.Login(adminLogindto);
                return Ok(new { token });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }



        [HttpGet("getadmins")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admin>))]
        public async Task<IActionResult> GetAdmins()
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

        //Add Departments
        [HttpPost("adddepartment")]
        [ProducesResponseType(201, Type = typeof(Department))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [Authorize]
        public IActionResult AddDepartment([FromBody] AddDepartmentDto departmentDto)
        {
            return Ok(new { message = _adminServices.AddDepartment(departmentDto) });
        }

        //Add ProgrammeSemester
        [HttpPost("addprogrammesemester")]
        [ProducesResponseType(201, Type = typeof(ProgrammeSemester))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddProgrammeSemester([FromBody] ProgrammeSemesterDto programmeSemesterDto)
        {
            return Ok(new { message = _adminServices.AddProgrammeSemester(programmeSemesterDto) });
        }

        //Add ExamSchedule
        [HttpPost("addexamschedule")]
        [ProducesResponseType(201, Type = typeof(ExamSchedule))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddExamSchedule([FromBody] ExamScheduleDto examScheduleDto)
        {
            return Ok(new { message = _adminServices.addExamSchedule(examScheduleDto) });
        }

        //Add Course
        [HttpPost("addcourse")]
        [ProducesResponseType(201, Type = typeof(Course))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddCourse([FromBody] CourseDto courseDto)
        {
            return Ok(new { message = _adminServices.AddCourse(courseDto) });
        }

        //Add Links
        [HttpPost("addlink")]
        [ProducesResponseType(201, Type = typeof(Links))]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult AddLink([FromBody] LinkDto linkDto)
        {
            return Ok(new { message = _adminServices.AddLink(linkDto) });
        }


        //Generate Exam Schedule
        [HttpGet("fetchexamschedule")]
        public IActionResult GenerateExamSchedule()
        {
            return Ok(new { info = _adminServices.FetchExamSchedules() });
        }

        [HttpGet("getLinkedcourses")]
        public IActionResult GetLinkedCourses()
        {
            return Ok(new { info = _adminServices.GetLinkedCourses() });
        }

        [HttpGet("getLinkedCourseDatePriority")]
        public IActionResult GetLinkedCourseDatePriority()
        {
            return Ok(new { info = _adminServices.GetLinkCourseDatePriority() });
        }

        [HttpGet("getLinkedCoursesWithoutPriority")]
        public IActionResult GetLinkedCoursesWithoutPriority()
        {
            return Ok(new { info = _adminServices.GetLinkedCoursesWithoutPriority() });
        }
    }
}
