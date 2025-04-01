using GenricWebApiemo.Models;
using GenricWebApiemo.SchoolDb;
using Microsoft.EntityFrameworkCore;

namespace GenricWebApiemo.Repos
{
    public class ProductService : GenricService<Student>, IProductService
    {
      

        private readonly SchoolDbConnection _schoolDbConnection;
        public ProductService(SchoolDbConnection schoolDbConnection) : base(schoolDbConnection)
        {
            _schoolDbConnection = schoolDbConnection;
        }

        public async Task<List<Student>> GetByNameAnId(int id, string name)
        {
            var result = await _schoolDbConnection.Students.Where(x => x.Id == id && x.StudentName == name).ToListAsync();
            return result;
        }
    }
}
