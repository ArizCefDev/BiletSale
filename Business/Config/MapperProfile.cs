using AutoMapper;
using DataAccess.Entity;
using DTO.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO.DTOEntity.BiletDTO;

namespace Business.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>()
                .ForMember(dst => dst.RoleName, x => x.MapFrom(src => src.Role.Name));

            CreateMap<BiletDTO, Bilet>();
            CreateMap<Bilet, BiletDTO>();

            CreateMap<AboutDTO, About>();
            CreateMap<About, AboutDTO>();

            CreateMap<CartDTO, Cart>();
            CreateMap<Cart, CartDTO>()
                .ForMember(dst => dst.BiletName, x => x.MapFrom(src => src.Bilet.Name))
                .ForMember(dst => dst.FlyDateName, x => x.MapFrom(src => src.Bilet.FlyDate))
                .ForMember(dst => dst.FlyTimeName, x => x.MapFrom(src => src.Bilet.FlyTime))
                .ForMember(dst => dst.DownDateName, x => x.MapFrom(src => src.Bilet.DownDate))
                .ForMember(dst => dst.DownTimeName, x => x.MapFrom(src => src.Bilet.DownTime))
                .ForMember(dst => dst.BiletKm, x => x.MapFrom(src => src.Bilet.Km))
                .ForMember(dst => dst.BiletPrice, x => x.MapFrom(src => src.Bilet.Price));
        }
    }
}
