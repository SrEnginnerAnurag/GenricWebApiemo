using MainGenericsDemoProject.ModelFolder;
using Microsoft.EntityFrameworkCore;

namespace MainGenericsDemoProject.GenericsDBContextFolder
{
    public class GenericsDbContextClass:DbContext
    {
        public GenericsDbContextClass(DbContextOptions<GenericsDbContextClass> options):base(options)
        {
            
        }
        public DbSet<StudentModel> StTable { get; set; } 
        public DbSet<CustomerModel> CoustomerTable { get; set; } 
    }
}
