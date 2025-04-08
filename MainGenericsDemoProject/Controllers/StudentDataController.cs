using MainGenericsDemoProject.ModelFolder;
using MainGenericsDemoProject.Repo.ServiceFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainGenericsDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        private readonly IGenericsService<StudentModel> _genericsService;
        public StudentDataController( IGenericsService<StudentModel> genericsService)
        {
            _genericsService = genericsService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexGetData() 
        {
            var ResItem = await _genericsService.ShowAllData();
            return Ok(ResItem);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> IndexGetByIdData(int id) 
        {
            var resItem = await _genericsService.ShowGetByIdData(id);
            return Ok(resItem);
        }

        [HttpPost]
        public async Task<IActionResult> IndexInsertData(StudentModel studentModel) 
        {
            var ResItem = await _genericsService.InsertStudentData(studentModel);
            return Ok(ResItem);
        }

        [HttpPut]
        public async Task<IActionResult> IndexUpdateData(int Id, StudentModel studentModel)
        {
            var reItem = await _genericsService.UpdateStudentData(Id, studentModel);
            return Ok(reItem);
        }

        [HttpDelete]
        public async Task<IActionResult> IndexDeleteData(int Id)
        {
            var ResItem = await _genericsService.DeleteStudentData(Id);
            return Ok(ResItem);
        }
    }
}
