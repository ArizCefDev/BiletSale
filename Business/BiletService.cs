using AutoMapper;
using Business.Abstract;
using DataAccess;
using DataAccess.Entity;
using DTO.DTOEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BiletService : BaseService<BiletDTO, Bilet, BiletDTO>, IBiletService
    {
        public BiletService(IMapper mapper, ApplicationDbContext dBContext) : base(mapper, dBContext)
        {
        }
        public void AddToCart(CartDTO dto)
        {
            var user = _dBContext.Users.Find(dto.UserId);

            if (user == null)
                throw new Exception("User not found!");

            var ent = _mapper.Map<Cart>(dto);

            user.Carts.Add(ent);

            _dBContext.SaveChanges();
        }

        public void Buy(int cartId)
        {
            var cart = _dBContext.Carts.Find(cartId);

            _dBContext.Carts.Remove(cart);
            _dBContext.SaveChanges();
        }

        public void DeleteFromCart(int cartId)
        {
            var ent = _dBContext.Carts.Find(cartId);

            if (ent == null)
                return;

            _dBContext.Carts.Remove(ent);

            _dBContext.SaveChanges();
        }

        public IEnumerable<CartDTO> GetCart(int userId)
        {
            var user = _dBContext.Users
                  .Where(u => u.Id == userId)
                  .Include(x => x.Carts)
                   .ThenInclude(x => x.Bilet)
                       .First();

            if (user == null)
                throw new Exception("User not found!");

            var res = _mapper.Map<IEnumerable<CartDTO>>(user.Carts);

            return res;
        }

        public IEnumerable<BiletDTO> GetFilter(out int prodCount, int page = 1, int pageSize = 2, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null)
        {
            var res = Get();
            prodCount = res.Count();

            if (!string.IsNullOrEmpty(search?.Trim()))
                res = res.Where(bk => bk.Name.ToLower().Contains(search.ToLower()));

            res = order switch
            {
                ProductSortOrder.NameDesc => res.OrderByDescending(s => s.Name),
                ProductSortOrder.PriceAsc => res.OrderBy(s => s.Price),
                ProductSortOrder.PriceDesc => res.OrderByDescending(s => s.Price),

                _ => res.OrderBy(s => s.Name),
            };

            var prods = res.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return prods;
        }
    }
}
