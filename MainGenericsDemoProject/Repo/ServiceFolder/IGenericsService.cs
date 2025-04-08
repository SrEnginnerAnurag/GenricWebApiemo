namespace MainGenericsDemoProject.Repo.ServiceFolder
{
    public interface IGenericsService<T>
    {
        Task<List<T>> ShowAllData();
        Task<T>ShowGetByIdData(int id);
        Task<T> InsertStudentData(T modelobject);
        Task<T> UpdateStudentData(int id ,T modelobject);
        Task<T> DeleteStudentData(int id);
    }
}
