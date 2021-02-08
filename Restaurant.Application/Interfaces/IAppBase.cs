using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Application.Interfaces
{
    public interface IAppBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {
        int Insert(TEntityDTO entityDTO);
        void Update(TEntityDTO entityDTO);
        void Delete(int id);
        void Delete(TEntityDTO entityDTO);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();

    }
}
