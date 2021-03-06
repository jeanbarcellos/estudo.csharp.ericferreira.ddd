using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        int Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
    }
}
