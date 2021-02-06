using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Insert(TEntity entity);
        void Upadte(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        TEntity GetByid(int id);
        IEnumerable<TEntity> GetAll();
    }
}
