using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;

namespace Service
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository iOrderRepository, IProductRepository productRepository, WebSiteContext webSiteContext)
        {
            _iOrderRepository = iOrderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> AddOrder(Order order)
        {
            List<int>productIds=new List<int>();
            var orderItems = order.OrderItems.ToArray();
            for (int i = 0; i < orderItems.Length; i++)
            {
                productIds.Add(orderItems[i].ProductId);
            }
            var products= new Product[order.OrderItems.Count];
            products= _productRepository.GetProductsByIDs(productIds.ToArray());
            var sum = 0;
            for (int i = 0; i < products.Length; i++)
            {

               sum += (products[i].Price) * (orderItems[i].Amount);
            }
            order.Price = sum;
            Order orderRes=await _iOrderRepository.AddOrder(order);
            if (orderRes != null)
                return orderRes;
            return null;
        }
    }
}
