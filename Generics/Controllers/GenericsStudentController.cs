using Generics.ModelFolder;
using Generics.Repo.GenericsInterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/students")]  // Change route to avoid conflicts     
    [ApiController]
    public class GenericsStudentController : ControllerBase
    {
        private readonly IStudentService<StudentModel> _studentService;
        public GenericsStudentController(IStudentService<StudentModel> studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetData() 
        {
            var res = await _studentService.ShowData();
            return Ok(res);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var item = await _studentService.GetDataById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostData(StudentModel studentModel)
        {
            var putitem = await _studentService.InsertData(studentModel);
            return Ok(putitem);
        }

        [HttpPut]
        public async Task<IActionResult> PutData( StudentModel studentModel)
        {
            var Update = await _studentService.UpdateData( studentModel);
            return Ok(Update);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteData(int Id)
        {
            var res = await _studentService.DeleteData(Id);
            return Ok(res); 
        }
    }
}
