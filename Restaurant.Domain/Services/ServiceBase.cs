using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Restaurant.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public int Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public TEntity GetById(int id)
        {
            return repository.GetByid(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

    }
}
