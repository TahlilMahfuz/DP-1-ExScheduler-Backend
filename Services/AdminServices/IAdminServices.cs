using ExScheduler_Server.Models;

namespace ExScheduler_Server.Services.AdminServices
{
    public interface IAdminServices
    {
        public ICollection<Admin> GetAdmins();
        public Task<Admin> GetByEmail(String adminemail);
        string ValidateCR(int id);
    }
}
