using ExScheduler_Server.Models;

namespace ExScheduler_Server.Interfaces
{
    public interface IAdminRepository
    {
        ICollection<Admin> GetAdmins();
        Admin GetAdminByEmail(String adminemail);
        bool EmailExistsAlready(string adminEmail);
        bool CreateAdmin(String AdminName,String AdminEmail,String AdminPassword,String AdminConfirmPassword);
        string generateJWTToken(Admin admin);
        bool ValidateCrByID(int id);
    }
}
