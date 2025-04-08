using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolManagementBussenesslogic.RepoFolder.InterfaceServiceFolder
{
    public interface IServiceClass<T>
    {
        Task<List<T>> ShowAllData();
        Task<T> GetByIdData(int id);
        Task<T> InsertData(T modelobject);
        Task<T> UpdateData(int Id ,T modelobject);
        Task<T> DeleteData(int Id);
    }
}
