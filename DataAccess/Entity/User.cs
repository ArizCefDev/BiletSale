using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
    }
}
