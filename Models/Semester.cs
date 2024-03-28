using System.ComponentModel.DataAnnotations;

namespace ExScheduler_Server.Models
{
    public class Semester
    {
        [Key]
        public Guid semesterID { get; set; }
        public string semesterName { get; set; } = default!;
        public List<Programme> programmes { get; set; } = default!;
        public List<Students> students { get; set; } = default!;
        public List<Course> courses { get; set; } = default!;
    }
}
