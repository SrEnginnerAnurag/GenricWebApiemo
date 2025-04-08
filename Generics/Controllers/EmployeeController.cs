using Generics.ModelFolder;
using Generics.Repo.GenericsInterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/employees")]  // Change route to avoid conflicts
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IStudentService<EmployeeModel> _studentService;
        public EmployeeController(IStudentService<EmployeeModel>  studentService)
        /*IStudentService<EmployeeModel>:

         Jab aap IStudentService<EmployeeModel> likhte hain, iska matlab hai ki aap IStudentService ko EmployeeModel type ke liye use kar rahe hain.

         Yani, aap IStudentService ka use EmployeeModel ke liye karna chahte hain.

         Iska fayda yeh hai ki aap IStudentService ko multiple different types ke liye reuse kar sakte hain. Jaise agar aapko StudentModel ke liye service chahiye ho, toh aap IStudentService<StudentModel> likhenge.*/
        {
            _studentService = studentService;   
        }

        [HttpGet]
        public async Task<IActionResult> EmpGetData()
        {
            var Empget = await _studentService.ShowData();
            return Ok(Empget);
        }

        [HttpGet("EmpGetById")]
        public async Task<IActionResult> EmpDataGEtbyid(int Id )
        {
            var EmpRes = await _studentService.GetDataById(Id);
            return Ok(EmpRes);
        }

        [HttpPost]
        public async Task<IActionResult> EmpPostData(EmployeeModel employeeModel)
        {
             var EmpPost = await _studentService.InsertData(employeeModel);
            return Ok(EmpPost);
        }

        [HttpPut]
        public async Task<IActionResult> EmpPutData(EmployeeModel employeeModel)
        {
            var EmpUpadte = await _studentService.UpdateData(employeeModel);
            return Ok(EmpUpadte);
        }
        [HttpDelete]
        public async Task<IActionResult> EmpDeleteData(int id)
        {
            var EmpDelete =  await _studentService.DeleteData(id);
            return Ok(EmpDelete);
        }
    }
}
