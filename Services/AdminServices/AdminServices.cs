using ExScheduler_Server.Interfaces;
using ExScheduler_Server.Models;

namespace ExScheduler_Server.Services.AdminServices
{
    public class AdminServices:IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        
        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public ICollection<Admin> GetAdmins()
        {
            return _adminRepository.GetAdmins();
        }

        public Task<Admin> GetByEmail(string adminemail)
        {
            return Task.FromResult(_adminRepository.GetAdminByEmail(adminemail));
        }
        public string ValidateCR(int id)
        {
            var cr = _adminRepository.ValidateCrByID(id);
            if (cr == null)
            {
                return "CR not found";
            }
            else
            {
                if (_adminRepository.ValidateCrByID(id))
                {
                    return "CR has been made valid";
                }
                else {
                    return "CR not found in the database";
                }
            }
        }
        
    }
}
