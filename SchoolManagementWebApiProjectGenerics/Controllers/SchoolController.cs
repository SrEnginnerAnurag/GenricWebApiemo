using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolManagementBussenesslogic.RepoFolder.InterfaceServiceFolder;
using SchoolMangementDto;

namespace GenericsSchoolManagementWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IServiceClass<TeacherDto> _serviceClass;
        public SchoolController(IServiceClass<TeacherDto> serviceClass)
        {
            _serviceClass = serviceClass;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var ShowData = await _serviceClass.ShowAllData();
            return Ok (ShowData);   
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> ShowDataGetById(int id)
        {
            var ShowData = await _serviceClass.GetByIdData(id);
            return Ok (ShowData);

        }

        [HttpPost]
        public async Task<IActionResult> AddData(TeacherDto teacherDto)
        {
            var ShowData = await _serviceClass.InsertData(teacherDto);
            return Ok (ShowData);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeData(int Id , TeacherDto teacherDto)
        {
            var ShowData = await _serviceClass.UpdateData(Id, teacherDto);
            return Ok (ShowData);
        }

        [HttpDelete]
        public async Task<IActionResult> DelelteData(int Id)
        {
            var ShowData = await _serviceClass.DeleteData(Id);
            return Ok (ShowData);
        }
    }
}
