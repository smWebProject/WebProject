using Microsoft.AspNetCore.Mvc;
using Service;
using Repository;
using Entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService iProductService, IMapper mapper)
        {
            _iProductService = iProductService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>>Get([FromQuery]string ?name, [FromQuery] int? price_from, [FromQuery] int? price_to, [FromQuery] int[] ?categoryIds, [FromQuery] int start, [FromQuery] int limit, [FromQuery] string? direction = "ASC", string? orderBy = "price")
        {
            var product = await _iProductService.GetProducts(name, price_from, price_to, categoryIds, start, limit, direction, orderBy);
            var productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(product);
            return productDTO;

        }

    }
}
