using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class About : BaseEntity
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
    }
}
