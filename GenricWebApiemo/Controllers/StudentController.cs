using GenricWebApiemo.Models;
using GenricWebApiemo.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GenricWebApiemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGenricService<Student> _genricService;
        public StudentController(IGenricService<Student> genricService)
        {
            _genricService = genricService;
        }
        [HttpGet]

        public async Task<IActionResult> GetStudents()
        {
            var result = await _genricService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewStudent(Student student)
        {
            var result = await _genricService.CreateAsync(student);
            return Ok("Data Added successfull");

        }

        [HttpPut]
        public async Task<IActionResult> UodateStudentData(Student student)
        {
            var res = await _genricService.UpdateAsync(student);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentData(int id)
        {
            var res = _genricService.DeleteAsync(id);
            return Ok(res);
        }

        [HttpGet("StudentDataGetById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var res = await _genricService.GetById(id);
            return Ok(res);
        }
    }
}
