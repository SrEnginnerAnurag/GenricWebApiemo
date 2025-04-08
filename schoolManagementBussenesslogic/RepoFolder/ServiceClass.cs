using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using schoolManagementBussenesslogic.RepoFolder.InterfaceServiceFolder;
using SchoolManagementModel.DbContexFolder;

namespace schoolManagementBussenesslogic.RepoFolder
{
    public class ServiceClass<TModel , TDto>:IServiceClass<TDto> where TModel : class
    {
        private readonly TeacherDbContext _teacherDbContext;
        private readonly DbSet<TModel> _dbsetmodeltAble;
        private readonly IMapper _mapper;

        public ServiceClass(TeacherDbContext teacherDbContext , IMapper mapper)
        {
            _teacherDbContext = teacherDbContext;
            _dbsetmodeltAble = _teacherDbContext.Set<TModel>();
            _mapper = mapper;
        }

        public async Task<List<TDto>> ShowAllData()
        {
           var Item  = await _dbsetmodeltAble.ToListAsync();
            var mapedData = _mapper.Map<List<TDto>>(Item);
            return mapedData;
        }

        public async Task<TDto> GetByIdData(int id)
        {
            var item = await _dbsetmodeltAble.FindAsync(id);
            if (item == null) 
            {
                throw new Exception("Please Ginve the correct Id.");
            }
            var mapedData = _mapper.Map<TDto>(item);
            return mapedData;
        }

        public async Task<TDto> InsertData(TDto modelobject)
        {
            if (modelobject == null)
            {
                throw new Exception("Data is not found.");
            }
            var changedData = _mapper.Map<TModel>(modelobject);

             await _dbsetmodeltAble.AddAsync(changedData);

            var MapedData = _mapper.Map<TDto>(modelobject);

           await  _teacherDbContext.SaveChangesAsync();
            return MapedData;
        }

        public async Task<TDto> UpdateData(int Id, TDto modelobject)
        {
            var item = await _dbsetmodeltAble.FindAsync(Id);
            if (item == null)
            {
                throw new Exception("please give the correct Id.");
            }
            var changeData = _mapper.Map(modelobject, item);

             _dbsetmodeltAble.Update(changeData);

            var MapedData = _mapper.Map<TDto>(modelobject);

            await _teacherDbContext.SaveChangesAsync();
            return MapedData;
        }

        public async Task<TDto> DeleteData(int Id)
        {
            var item = await _dbsetmodeltAble.FindAsync(Id);
            if (item == null)
            {
                throw new Exception("Please give the Correct Id, your Id is not Found.");
            }
            var  res = _teacherDbContext.Remove(item);

            var mapedData = _mapper.Map<TDto>(res);

            await _teacherDbContext.SaveChangesAsync();

            return mapedData;

        }




    }
}
