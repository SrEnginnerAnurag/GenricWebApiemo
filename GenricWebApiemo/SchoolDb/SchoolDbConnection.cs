using GenricWebApiemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GenricWebApiemo.SchoolDb
{
    public class SchoolDbConnection :DbContext
    {
        public SchoolDbConnection(DbContextOptions<SchoolDbConnection> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
