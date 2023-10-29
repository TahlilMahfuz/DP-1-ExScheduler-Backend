namespace ExScheduler_Server.Models
{
    public class Semester
    {
        public Guid semesterID { get; set; }
        public string semesterName { get; set; } = default!;
        public List<Programme> programmes { get; set; } = default!;
        public List<Students> students { get; set; } = default!;
    }
}
