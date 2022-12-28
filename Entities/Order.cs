using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Date = DateTime.UtcNow.ToLocalTime();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }= DateTime.UtcNow.ToLocalTime();
        public int Price { get; set; } 
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User  ? User { get; set; } = null!;
        public virtual ICollection<OrderItem>  OrderItems { get; set; }
    }
}
