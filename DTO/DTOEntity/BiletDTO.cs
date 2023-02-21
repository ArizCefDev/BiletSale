using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public enum ProductSortOrder
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
    public class BiletDTO
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime FlyDate { get; set; }
        public DateTime FlyTime { get; set; }
        public DateTime DownDate { get; set; }
        public DateTime DownTime { get; set; }
        public string? Km { get; set; }
        public double Price { get; set; }
    }
}
