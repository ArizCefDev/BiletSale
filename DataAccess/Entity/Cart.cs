using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public int BiletId { get; set; }
        public Bilet Bilet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Count { get; set; }
    }
}
