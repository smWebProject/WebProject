using Microsoft.AspNetCore.Mvc;
using Service;
using Repository;
using Entities;
using AutoMapper;
using DTO;
using System.Collections.Generic;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _iCategoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService iCategoryService, IMapper mapper)
        {
            _iCategoryService = iCategoryService;
            _mapper = mapper;

        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>>Get()
        {
            var categories = await _iCategoryService.GetAllCategories();
            var categoryDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            return categoryDTO;
        }

    }
}
