using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolManagementBussenesslogic.RepoFolder.InterfaceServiceFolder;
using SchoolManagementDto;
using SchoolManagementModel.DbContexFolder;
using SchoolManagementModel.MolderFolder;

namespace GenericsSchoolManagementWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IServiceClass<StudentDto> _serviceClass;
        public StudentController(IServiceClass<StudentDto> serviceClass)
        {
            _serviceClass = serviceClass;   

        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var res = await _serviceClass.ShowAllData();
            return Ok(res);
        }

        [HttpGet("getbyId")]
        public async Task<IActionResult> ShowGetById(int id)
        {
            var res = await _serviceClass.GetByIdData(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            var res = await _serviceClass.InsertData(studentDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id , StudentDto studentDto)
        {
            var res = await _serviceClass.UpdateData(Id, studentDto);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var res = await _serviceClass.DeleteData(id);
            return Ok(res);
        }

    }
}
