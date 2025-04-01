
using GenricWebApiemo.SchoolDb;
using Microsoft.EntityFrameworkCore;

namespace GenricWebApiemo.Repos
{
    public class GenricService<T> : IGenricService<T> where T : class
    {
        private readonly SchoolDbConnection _schoolDbConnection;
        private readonly DbSet<T> _dbset;
        public GenricService(SchoolDbConnection schoolDbConnection)
        {
            _schoolDbConnection = schoolDbConnection;
            _dbset = _schoolDbConnection.Set<T>();
        }


        public async Task<T> CreateAsync(T input)
        {
            await _dbset.AddAsync(input);
            await _schoolDbConnection.SaveChangesAsync();
            return input;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbset.FindAsync(id);
            if(result ==null)
            {
                throw new Exception("result not found");
            }
            _dbset.Remove(result);
            await _schoolDbConnection.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           var result = await _dbset.ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await _dbset.FindAsync(id);
            if (result == null)
            {
                throw new Exception("result not found");
            }
            return result;
        }

        public async Task<T> UpdateAsync(T input)
        {
            _dbset.Update(input);
            await _schoolDbConnection.SaveChangesAsync();
            return input;
        }
    }
}
