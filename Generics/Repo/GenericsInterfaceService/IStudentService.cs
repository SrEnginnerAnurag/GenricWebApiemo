namespace Generics.Repo.GenericsInterfaceService
{
    public interface IStudentService<T>
    {
        Task<List<T>> ShowData();
        Task<T> GetDataById(int id);

        Task<T> InsertData(T input);
        Task<T> UpdateData(T input);

        Task<T> DeleteData(int Id);
    }
}
