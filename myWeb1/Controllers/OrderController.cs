using Microsoft.AspNetCore.Mvc;
using Service;
using Repository;
using Entities;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _iOrderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService iOrderService, IMapper mapper)
        {
            _iOrderService = iOrderService;
            _mapper = mapper;

        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] OrderDto orderDto)
        {
            var order = _mapper.Map<OrderDto, Order>(orderDto);
            Order orderRes = await _iOrderService.AddOrder(order);
            return orderRes;
        }


    }
}
