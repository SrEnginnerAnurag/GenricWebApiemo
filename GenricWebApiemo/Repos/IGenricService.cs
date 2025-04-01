namespace GenricWebApiemo.Repos
{
    public interface IGenricService<T>
    {
        Task<T> CreateAsync(T input);
        Task<T> UpdateAsync(T input);

        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();

        Task<T> GetById(int id);


    }


}
