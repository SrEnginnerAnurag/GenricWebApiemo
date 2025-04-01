using GenricWebApiemo.Models;

namespace GenricWebApiemo.Repos
{
    public interface IProductService :IGenricService<Student>
    {
        Task<List<Student>> GetByNameAnId(int id, string name);
    }
}
