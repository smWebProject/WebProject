using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;

namespace Service
{//hnhg
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;
        private readonly IProductService _productService;
        public OrderService(IOrderRepository iOrderRepository, IProductService productService, WebSiteContext webSiteContext)
        {
            _iOrderRepository = iOrderRepository;
            _productService = productService;
        }

        public async Task<Order> AddOrder(Order order)
        {
            
            //var products = _productService.GetProducts();
            var sum = 0;
            var arr = order.OrderItems.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i].Product.Price;
            }
            Order orderRes=await _iOrderRepository.AddOrder(order);
            if (orderRes != null)
                return orderRes;
            return null;
        }
    }
}
