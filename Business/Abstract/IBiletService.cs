using DataAccess.Entity;
using DTO.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBiletService : IBaseService<BiletDTO, Bilet, BiletDTO>
    {
        public IEnumerable<BiletDTO> GetFilter(out int prodCount, int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null);
        public void AddToCart(CartDTO dto);
        public IEnumerable<CartDTO> GetCart(int userId);
        public void DeleteFromCart(int cartId);
        public void Buy(int cartId);
    }
}
