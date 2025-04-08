using GenericsApiDtoAndAutomapper.DtoFolder;
using GenericsApiDtoAndAutomapper.ModelFolder;
using GenericsApiDtoAndAutomapper.RepoFolder.ServiceFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericsApiDtoAndAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService<EmployeeDto> _employeeService;
        public EmployeeController(IEmployeeService<EmployeeDto> employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var ItemRes = await _employeeService.ShowAllData();
            return Ok(ItemRes); 
        }

        [HttpGet("EmpGetById")]
        public async Task<IActionResult> EmpGetByIdData(int Id)
        {
            var res = await _employeeService.ShowgetbyIdData(Id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> EmpAddData(EmployeeDto employeeDto)
        {
            var res = await _employeeService.InsertData(employeeDto);
            return Ok(res); 
        }

        [HttpPut]
        public async Task<IActionResult> EmpPutData(int Id , EmployeeDto employeeDto)
        {
            var item = await _employeeService.UpdateData(Id , employeeDto);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> EmpDeleteData(int Id)
        {
            var DeleteItem = await _employeeService.DeleteData(Id);
            return Ok(DeleteItem);
        }


    }
}
