using System;
using System.Collections.Generic;

namespace T_Repository
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Code { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
