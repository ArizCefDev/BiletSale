using AutoMapper;
using Business.Abstract;
using DataAccess;
using DataAccess.Entity;
using DTO.DTOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AboutService : BaseService<AboutDTO, About, AboutDTO>, IAboutService
    {
        public AboutService(IMapper mapper, ApplicationDbContext dBContext) : base(mapper, dBContext)
        {
        }
    }
}
