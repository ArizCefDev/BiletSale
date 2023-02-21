using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Sum { get => Count * BiletPrice; }
        public int BiletId { get; set; }
        public string? BiletName { get; set; }
        public DateTime FlyDateName { get; set; }
        public DateTime FlyTimeName { get; set; }
        public DateTime DownDateName { get; set; }
        public DateTime DownTimeName { get; set; }
        public string? BiletKm { get; set; }
        public double BiletPrice { get; set; }
        public int UserId { get; set; }
    }
}
