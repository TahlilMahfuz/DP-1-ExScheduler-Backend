using ExScheduler_Server.Data;
using ExScheduler_Server.Interfaces;
using ExScheduler_Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExScheduler_Server.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public StudentRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
        public bool EmailExistsAlready(string crEmail)
        {
            return _context.Students.Any(cr => cr.StudentEmail == crEmail);
        }  
        public Students GetClassRepresentativeByEmail(string studentemail)
        {
            return _context.Students.FirstOrDefault(p => p.StudentEmail == studentemail);
        }
        public ICollection<Students> GetClassRepresentatives()
        {
            return _context.Students.OrderBy(p => p.StudentID).ToList();
        }
        public string generateJWTToken(Students classRepresentative)
        {
            // Generate JWT token
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("StudentID", classRepresentative.StudentID.ToString()),
                        new Claim("StudentEmail", classRepresentative.StudentEmail),
                        new Claim("StudentName", classRepresentative.StudentName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public bool CreateClassRepresentative(int StudentID, string StudentName, string StudentEmail, string StudentPassword, string Salt)
        {
            Students classRepresentative = new Students();
            classRepresentative.StudentID = StudentID;
            classRepresentative.StudentName = StudentName;
            classRepresentative.StudentEmail = StudentEmail;
            classRepresentative.StudentPassword = StudentPassword;
            classRepresentative.Salt = Salt;
            _context.Add(classRepresentative);
            return Save();
        }
    }
}
