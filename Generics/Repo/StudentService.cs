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

        public async Task<T> DeleteData(int Id)
        {
            var result = await _DbSetStudent.FindAsync(Id);
            if ( result == null) 
            {
                throw new Exception("Your id is not found");
            }
            _studentDbContext.Remove(result);
            await _studentDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<T> GetDataById(int id)
        {
           var res = await _DbSetStudent.FindAsync(id);
            if (res == null) 
            {
                throw new Exception("Id is not found.");
            }
            await _studentDbContext.SaveChangesAsync();
            return res;  
        }

        public async Task<T> InsertData(T input)
        {
            await _DbSetStudent.AddAsync(input);
            if (input == null)
            {
                throw new Exception("Data is not Inserted.");
            }
            await _studentDbContext.SaveChangesAsync();
            return input; // Jab hum data insert karte hain, toh hum generally us data ko return karte hain taaki caller (for example, controller) ko yeh confirmation mil sake ki data sahi se insert ho gaya.
        }

        public async Task<List<T>> ShowData()
        {
            var getitem = await _DbSetStudent.ToListAsync();
            if (getitem == null)
            {
                throw new Exception("Data is the null.");
            }
            await _studentDbContext.SaveChangesAsync();
            return getitem;
        }

        public async Task<T> UpdateData(T input)
        {
            _DbSetStudent.Update(input);
            if (input == null)
            {
                throw new Exception("your Id is Not Found.");
            }
            await _studentDbContext.SaveChangesAsync();
            return input;

        }
    }
}
