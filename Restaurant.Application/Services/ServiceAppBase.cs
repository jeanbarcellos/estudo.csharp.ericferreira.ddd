using AutoMapper;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Restaurant.Application.Services
{
    public class ServiceAppBase<TEntity, TEntityDTO> : IAppBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {

        protected readonly IMapper iMapper;
        protected readonly IServiceBase<TEntity> service;

        public ServiceAppBase(IMapper iMapper, IServiceBase<TEntity> service)
        {
            this.iMapper = iMapper;
            this.service = service;
        }

        public int Insert(TEntityDTO entity)
        {
            return service.Insert(iMapper.Map<TEntity>(entity));
        }

        public void Update(TEntityDTO entity)
        {
            service.Update(iMapper.Map<TEntity>(entity));
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Delete(TEntityDTO entity)
        {
            service.Delete(iMapper.Map<TEntity>(entity));
        }

        public TEntityDTO GetById(int id)
        {
            return iMapper.Map<TEntityDTO>(service.GetById(id));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return iMapper.Map<IEnumerable<TEntityDTO>>(service.GetAll());
        }

    }
}
