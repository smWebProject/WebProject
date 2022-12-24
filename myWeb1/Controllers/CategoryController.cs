using Microsoft.AspNetCore.Mvc;
using Service;
using T_Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _iCategoryService;

        public CategoryController(ICategoryService iCategoryService)
        {
            _iCategoryService = iCategoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category?>>Get()
        {

            var categories = await _iCategoryService.GetAllCategories();
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        //public async Task<Category?> Get([FromQuery] int?[] categoryIds)
        //{
        //    var category = await _iCategoryService.GetCategories(categoryIds);
        //    return category;
        //}

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
