using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<RsDTO, TEntity, RqDTO>
    {
        IEnumerable<RsDTO> Get();
        RsDTO Get(int id);
        RsDTO Create(RqDTO dto);
        void Update(RqDTO dto);
        int Delete(int id);
    }
}
