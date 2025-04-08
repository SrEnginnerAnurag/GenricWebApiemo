using System.Threading.Tasks;
using AutoMapper;
using GenericsApiDtoAndAutomapper.DbContextFolder;
using GenericsApiDtoAndAutomapper.ModelFolder;
using GenericsApiDtoAndAutomapper.RepoFolder.ServiceFolder;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenericsApiDtoAndAutomapper.RepoFolder
{
    public class EmployeeService<TEntity , TDto> : IEmployeeService<TDto> where TEntity : class 
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly DbSet<TEntity> _employeeDbSetTable;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
            _employeeDbSetTable = _employeeDbContext.Set<TEntity>();
        }

        public async Task<List<TDto>> ShowAllData()
        {
          var resItem = await _employeeDbSetTable.ToListAsync();
            if (resItem == null)
            {
                throw new Exception("data is not found");
            }
            var MapItem = _mapper.Map<List<TDto>>(resItem);
            return MapItem;
        }


        public async Task<TDto> ShowgetbyIdData(int id)
        {
            var resGet = await _employeeDbSetTable.FindAsync(id);
            if (resGet == null)
            {
                throw new Exception("Your id Data is not found. please give the Correct Id.");
            }
            var MapItem = _mapper.Map<TDto>(resGet);
            return MapItem;
        }

        public async Task<TDto> InsertData(TDto modelObject)
        {

            if (modelObject == null)
            {
                throw new Exception(" your data is null");
            }
            var resItem = _mapper.Map<TEntity>(modelObject);
            await _employeeDbSetTable.AddAsync(resItem);
            var MapRes = _mapper.Map<TDto>(modelObject);
            await _employeeDbContext.SaveChangesAsync();
            return MapRes;
        }

        public async Task<TDto> UpdateData(int Id, TDto modelObject)
        {
            var resItem = await _employeeDbSetTable.FindAsync(Id);
            if (resItem == null)
            {
                throw new Exception("Your id is not found. Please give the Correct Id.");
            }
            
            _mapper.Map(modelObject, resItem); //Yaha pe AutoMapper ka use ho raha hai. AutoMapper automatically modelObject (DTO) ke properties ko resItem (Entity) ke corresponding properties mein copy kar deta hai.

           // Iska fayda yeh hai ki aapko manually har property ko copy nahi karna padta, AutoMapper apne aap mapping kar leta hai. Jaise agar modelObject ka Name hai aur resItem ka bhi Name hai, toh AutoMapper modelObject.Name ko resItem.Name mein copy kar dega.

            _employeeDbSetTable.Update(resItem);

            await _employeeDbContext.SaveChangesAsync();

            var Mapres = _mapper.Map<TDto>(resItem); //Jab resItem (entity) successfully update ho jata hai, toh aap AutoMapper ka use karke us entity ko DTO (type T) mein map kar rahe hain.

           // Yaha pe T ek generic type hai jo ki EmployeeDTO, ProductDTO ya koi bhi DTO ho sakta hai.Aap updated data ko DTO mein map kar rahe hain taaki client ko return kar sakein.

            return Mapres;
        }

        public async Task<TDto> DeleteData(int Id)
        {
            var resItem = await _employeeDbSetTable.FindAsync(Id);
            if (resItem == null)
            {
                throw new Exception("Your id is not found. Please give the Correct Id.");
            }

             _employeeDbSetTable.Remove(resItem);
            
            await _employeeDbContext.SaveChangesAsync();
            var MapedData = _mapper.Map<TDto>(resItem); // DTO return karo delete ke baad
            return MapedData;
        }

    }
}
