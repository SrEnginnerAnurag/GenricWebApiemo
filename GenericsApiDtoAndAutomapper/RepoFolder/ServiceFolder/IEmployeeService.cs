namespace GenericsApiDtoAndAutomapper.RepoFolder.ServiceFolder
{
    public interface IEmployeeService<T>
    {
        Task<List<T>> ShowAllData();
        Task<T> ShowgetbyIdData(int id);
        Task<T> InsertData(T modelObject);
        Task<T> UpdateData(int Id , T modelObject);
        Task<T> DeleteData(int Id);
    }
}
