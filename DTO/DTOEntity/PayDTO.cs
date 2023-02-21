using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class PayDTO
    {
        public int CartId { get; set; }
        public int Sum { get; set; }
        public int Count { get; set; }
        public int ItemPrice { get; set; }
    }
}
