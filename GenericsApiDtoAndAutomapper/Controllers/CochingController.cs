using GenericsApiDtoAndAutomapper.DtoFolder;
using GenericsApiDtoAndAutomapper.RepoFolder.ServiceFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericsApiDtoAndAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CochingController : ControllerBase
    {
        private readonly IEmployeeService<CochingDto> _employeeService;
        public CochingController(IEmployeeService<CochingDto> employeeService)
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
        public async Task<IActionResult> EmpAddData(CochingDto CochingDto)
        {
            var res = await _employeeService.InsertData(CochingDto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> EmpPutData(int Id, CochingDto CochingDto)
        {
            var item = await _employeeService.UpdateData(Id, CochingDto);
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

