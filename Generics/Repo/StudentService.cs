using Generics.Repo.GenericsInterfaceService;
using Generics.StudentDbFolder;
using Microsoft.EntityFrameworkCore;

namespace Generics.Repo
{
    public class StudentService<T> : IStudentService<T> where T : class
    {
       private readonly StudentDbContext _studentDbContext;
       private readonly DbSet<T> _DbSetStudent;
        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
            _DbSetStudent = _studentDbContext.Set<T>();
        }

        public Task<T> DeleteData(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertData(T input)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ShowData()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateData(T input)
        {
            throw new NotImplementedException();
        }
    }
}
