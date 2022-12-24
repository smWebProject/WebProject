using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Repository;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
    }
}
