using GenericsApiDtoAndAutomapper.ModelFolder;
using Microsoft.EntityFrameworkCore;

namespace GenericsApiDtoAndAutomapper.DbContextFolder
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
            
        }
        public DbSet<EmployeeModel> EmployeeTable { get; set; }
       public DbSet<CochingModel> CochingTable { get; set; }
    }
}
