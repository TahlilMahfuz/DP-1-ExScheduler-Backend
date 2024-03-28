using ExScheduler_Server.Dto;
using ExScheduler_Server.Models;

namespace ExScheduler_Server.Services.AdminServices
{
    public interface IAdminServices
    {
        public ICollection<Admin> GetAdmins();
        public Task<Admin> GetByEmail(String adminemail);
        string ValidateCR(int id);
        string AddDepartment(AddDepartmentDto departmentDto);
        string AddProgrammeSemester(ProgrammeSemesterDto programmeSemesterDto);
        string addExamSchedule(ExamScheduleDto examScheduleDto);
        string AddCourse(CourseDto courseDto);
        string AddLink(LinkDto linkDto);
        ICollection<RoutineDto> FetchExamSchedules();
        ICollection<linkedCoursesWithProgSem> GetLinkedCourses();
        ICollection<LinkCourseDatePriorityDto> GetLinkCourseDatePriority();
        ICollection<LinkedCoursesWIthoutPriority> GetLinkedCoursesWithoutPriority();
    }
}
