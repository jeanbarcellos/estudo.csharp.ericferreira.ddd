using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Application.Interfaces
{
    public interface IAppBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {
        int Insert(TEntityDTO entidade);
        void Update(TEntityDTO entidade);
        void Delete(int id);
        void Delete(TEntityDTO entidade);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();

    }
}
