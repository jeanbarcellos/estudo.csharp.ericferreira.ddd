using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Restaurant.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public int Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public TEntity GetById(int id)
        {
            return _repository.FindById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.FindAll();
        }

    }
}
