using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementModel.MolderFolder;

namespace SchoolManagementModel.DbContexFolder
{
    public class TeacherDbContext:DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options):base(options)
        {
            
        }

        public DbSet<TeachersModel> TeacherTable { get; set; }
        public DbSet<StudentModel> StudentTable { get; set; }
    }
}
