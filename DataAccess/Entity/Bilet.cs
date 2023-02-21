using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Bilet : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime FlyDate { get; set; }
        public DateTime FlyTime { get; set; }
        public DateTime DownDate { get; set; }
        public DateTime DownTime { get; set; }
        public string? Km { get; set; }
        public double Price { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
