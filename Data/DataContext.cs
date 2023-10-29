using ExScheduler_Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ExScheduler_Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Students> Students { get; set; }
        public DbSet<Programme> Programs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
