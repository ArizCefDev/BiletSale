using AutoMapper;
using Business.Abstract;
using DataAccess.Entity;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BaseService<RqDTO, TEntity, RsDTO>
        : IBaseService<RsDTO, TEntity, RqDTO> where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _dBContext;
        protected readonly DbSet<TEntity> _dBSet;

        public BaseService(IMapper mapper, ApplicationDbContext dBContext)
        {
            _mapper = mapper;
            _dBContext = dBContext;
            _dBSet = dBContext.Set<TEntity>();
        }

        public virtual int Delete(int id)
        {
            var ent = _dBSet.Find(id);
            _dBSet.Remove(ent);
            _dBContext.SaveChanges();
            return ent.Id;
        }

        public virtual IEnumerable<RsDTO> Get()
        {
            var ent = _dBSet.ToList();
            var rsdto = _mapper.Map<IEnumerable<RsDTO>>(ent);
            return rsdto;
        }

        public virtual RsDTO Get(int id)
        {
            var ent = _dBSet.Find(id);
            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public virtual RsDTO Create(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
            ent.CreatedDate = DateTime.Now;

            _dBSet.Add(ent);
            _dBContext.SaveChanges();

            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public virtual void Update(RqDTO dto)
        {
            var ent = _mapper.Map<TEntity>(dto);
            ent.UpdatedDate = DateTime.Now;

            _dBSet.Update(ent);
            _dBContext.SaveChanges();
        }
    }
}
