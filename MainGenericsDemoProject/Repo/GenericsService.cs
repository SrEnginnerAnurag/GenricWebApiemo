using MainGenericsDemoProject.GenericsDBContextFolder;
using MainGenericsDemoProject.Repo.ServiceFolder;
using Microsoft.EntityFrameworkCore;

namespace MainGenericsDemoProject.Repo
{
    public class GenericsService<T>:IGenericsService<T> where T : class
    {
       private readonly GenericsDbContextClass _contextClass;
        private readonly DbSet<T> _GenericsdbSet;
        public GenericsService(GenericsDbContextClass genericsDbContextClass)
        {
            _contextClass = genericsDbContextClass;
            _GenericsdbSet =  _contextClass.Set<T>();
        }

        public async Task<List<T>> ShowAllData()
        {
           var itemres = await _GenericsdbSet.ToListAsync();
            if (itemres == null)
            {
                throw new Exception("Data is not Found.");
            }
            await _contextClass.SaveChangesAsync();
            return itemres;
        }

        public async Task<T> ShowGetByIdData(int id)
        {
            var itemres = await _GenericsdbSet.FindAsync(id);
            if (itemres == null)
            {
                throw new Exception("Yuor Id is not Found. Please Enter the Correct Id.");
            }
            await _contextClass.SaveChangesAsync();
            return itemres;
        }

        public async Task<T> InsertStudentData(T modelobject)
        {
            _GenericsdbSet.Add(modelobject);
            if (modelobject == null)
            {
                throw new Exception("Data is not Found.");
            }
            await _contextClass.SaveChangesAsync();
            return modelobject;
        }

        public async Task<T> UpdateStudentData(int id, T modelobject)
        {
            _GenericsdbSet.Update(modelobject);
            if (modelobject == null) 
            {
                throw new Exception("Your Id is not found. please Enter the correct Id.");
            }
            await _contextClass.SaveChangesAsync();
            return modelobject;
        }

        public async Task<T> DeleteStudentData(int id)
        {
            var itemres = await _GenericsdbSet.FindAsync(id);
            if (itemres == null)
            {
                throw new Exception("Your id is not found. Please Enter the Correct Id.");
            }
            await _contextClass.SaveChangesAsync();
            return itemres;
        }




    }
}
