using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
