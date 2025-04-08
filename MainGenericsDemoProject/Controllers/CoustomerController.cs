using MainGenericsDemoProject.ModelFolder;
using MainGenericsDemoProject.Repo.ServiceFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainGenericsDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoustomerController : ControllerBase
    {
        private readonly IGenericsService<CustomerModel> _genericsService;
        public CoustomerController(IGenericsService<CustomerModel> genericsService)
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
        public async Task<IActionResult> IndexInsertData(CustomerModel  customerModel)
        {
            var ResItem = await _genericsService.InsertStudentData(customerModel);
            return Ok(ResItem);
        }

        [HttpPut]
        public async Task<IActionResult> IndexUpdateData(int Id, CustomerModel customerModel)
        {
            var reItem = await _genericsService.UpdateStudentData(Id, customerModel);
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

