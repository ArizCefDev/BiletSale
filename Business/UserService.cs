using AutoMapper;
using Business.Abstract;
using DataAccess;
using DataAccess.Entity;
using DTO.DTOEntity;
using Helper.Constants;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {
        public UserService(IMapper mapper, ApplicationDbContext dBContext) : base(mapper, dBContext)
        {
        }

        public UserDTO Login(UserDTO model)
        {

            var res = _dBContext.Users
            .Where(x => x.UserName == model.UserName)
             .Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();



                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Şifrə yalnışdır!");
                }
            }
            else
            {
                throw new Exception("Hesab mövcud deyil");
            }

        }

        public override UserDTO Create(UserDTO model)
        {
            var res = _dBContext.Users.Where(x => x.UserName == model.UserName);

            var role = _dBContext.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
            model.RoleId = role.Id;

            if (res.Any())
                throw new Exception("Username exists!");


            model.Salt = Crypto.GenerateSalt();
            model.PasswordHash = Crypto.GenerateSHA256Hash(model.Password, model.Salt);

            return base.Create(model);
        }
    }
}
