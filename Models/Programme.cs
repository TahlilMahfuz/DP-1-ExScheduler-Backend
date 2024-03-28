using System.ComponentModel.DataAnnotations;

namespace ExScheduler_Server.Models
{
    public class Programme
    {
        [Key]
        public Guid programID { get; set; }
        public string programName { get; set; } = default!;
        public List<Students> Students { get; set; } = default!;   
        public Department department { get; set; } = default!;
    }
}
