using ExScheduler_Server.Data;
using ExScheduler_Server.Interfaces;
using ExScheduler_Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExScheduler_Server.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AdminRepository(DataContext context,IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public Admin GetAdminByEmail(string adminemail)
        {
            return _context.Admins.FirstOrDefault(p => p.AdminEmail == adminemail);
        }

        public ICollection<Admin> GetAdmins()
        {
            return _context.Admins.OrderBy(p => p.AdminID).ToList();
        }

        public bool CreateAdmin(string AdminName, string AdminEmail, string AdminPassword,string Salt)
        {
            Admin admin = new Admin();
            admin.AdminName = AdminName;
            admin.AdminEmail = AdminEmail;
            admin.AdminPassword = AdminPassword;
            admin.Salt = Salt;
            _context.Add(admin);
            return Save();
        }

        public bool EmailExistsAlready(string adminEmail)
        {
            return _context.Admins.Any(admin => admin.AdminEmail == adminEmail);
        }

        public string generateJWTToken(Admin admin)
        {
            // Generate JWT token
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AdminID", admin.AdminID.ToString()),
                        new Claim("AdminEmail", admin.AdminEmail),
                        new Claim("AdminName", admin.AdminName)
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
        public bool ValidateCrByID(int id)
        {
            var cr = _context.Students.FirstOrDefault(p => p.StudentID == id);
            if (cr != null)
            {
                cr.Validity = true;
                _context.Update(cr);
                return Save();
            }
            return false;
        }

    }
}
