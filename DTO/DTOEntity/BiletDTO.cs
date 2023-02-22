using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Zəhmət olmasa Təyinat yerlərini daxil edin")]
        public string? Name { get; set; }

        public DateTime FlyDate { get; set; }
        public DateTime FlyTime { get; set; }
        public DateTime DownDate { get; set; }
        public DateTime DownTime { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa Məsafəni daxil edin")]
        public string? Km { get; set; }

        public double Price { get; set; }
    }
}
