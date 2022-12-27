using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;
using Entities;

namespace Service
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;
        public OrderService(IOrderRepository iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
        }

     public async Task<Order> AddOrder(Order order)
        {
            Order orderRes=await _iOrderRepository.AddOrder(order);
            if (orderRes != null)
                return orderRes;
            return null;
        }
    }
}
