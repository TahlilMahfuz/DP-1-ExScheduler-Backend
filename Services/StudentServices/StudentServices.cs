using ExScheduler_Server.Dto;
using ExScheduler_Server.Interfaces;

namespace ExScheduler_Server.Services.StudentServices
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _CRRepository;
        public StudentServices(IStudentRepository cRRepository)
        {
            _CRRepository = cRRepository;
        }

        public ICollection<string> GetCourses()
        {
            return _CRRepository.GetCourses();
        }

        public ICollection<GetExamDateAndCourseDto> GetExamDatesAndCourses()
        {
            return _CRRepository.GetExamDatesAndCourses();
        }

        public string postDatesWithPriority(ICollection<LinkDatesDto> linkDates)
        {
            return _CRRepository.postDatesWithPriority(linkDates);
        }

        public string postStudentPreference(ICollection<PostStudentPreferenceDto> postStudentPreferenceDtos)
        {
            return _CRRepository.postStudentPreference(postStudentPreferenceDtos);
        }


        ICollection<linkedCoursesDto> IStudentServices.GetLinkedCourses()
        {
            return _CRRepository.GetLinkedCourses();
        }
    }
}
