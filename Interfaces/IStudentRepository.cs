using ExScheduler_Server.Models;

namespace ExScheduler_Server.Interfaces
{
    public interface IStudentRepository
    {
        bool EmailExistsAlready(string crEmail);
        ICollection<Students> GetClassRepresentatives();
        public bool CreateClassRepresentative(int StudentID,string StudentName, string StudentEmail, string StudentPassword, string Salt);
        string generateJWTToken(Students cr);
        Students GetClassRepresentativeByEmail(string studentemail);
    }
}
