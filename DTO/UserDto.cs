using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {

        public int Id { get; set; }
        [StringLength(8)]
        public string FirstName { get; set; } = null!;
        [StringLength(8)]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string UserName { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
