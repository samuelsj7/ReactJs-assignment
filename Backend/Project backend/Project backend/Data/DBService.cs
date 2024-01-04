using Microsoft.EntityFrameworkCore;
using Project_backend.Models;

namespace Project_backend.Data
{
    public class DBService:DbContext
    {
        public DBService(DbContextOptions<DBService> options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure ResultModel as a keyless entity
            modelBuilder.Entity<ResultModel>().HasNoKey();
        }
        public DbSet<ResultModel> ResultModels { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AllocateClassroom> AllocateClassrooms { get; set; }
        public DbSet<AllocateSubject> AllocateSubjects { get; set; }



    }
}
