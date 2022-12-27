using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace T_Repository
{
    public class OrderRepository:IOrderRepository
    {
        WebSiteContext _context;
        public OrderRepository(WebSiteContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
