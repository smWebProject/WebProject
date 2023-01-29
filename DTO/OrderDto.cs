using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderItems = new HashSet<OrderItem>();
            Date = DateTime.UtcNow.ToLocalTime();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
