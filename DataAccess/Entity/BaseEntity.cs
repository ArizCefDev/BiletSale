using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedAt { get; set; }
    }
}
