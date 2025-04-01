using GenricWebApiemo.Models;
using GenricWebApiemo.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GenricWebApiemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenricService<Student> _genricService;
        public ProductController(IGenricService<Student> genricService)
        {
            _genricService = genricService;
        }

        //private readonly IProductService _genricService;
        //public ProductController(IProductService genricService)
        //{
        //    _genricService = genricService;
        //}

      

       

        //public async Task<IActionResult> GetStudentsByNameID(int id,string name)
        //{
        //    var result = await _genricService.GetByNameAnId(id,name);
        //    return Ok(result);
        //}




    }
}
