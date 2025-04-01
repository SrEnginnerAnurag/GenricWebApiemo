using Generics.ModelFolder;
using Microsoft.EntityFrameworkCore;

namespace Generics.StudentDbFolder
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {
            
        }

        public DbSet<StudentModel>StudentTable { get; set; }
    }
}
