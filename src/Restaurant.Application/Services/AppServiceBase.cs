using AutoMapper;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Restaurant.Application.Services
{
    abstract public class AppServiceBase<TEntity, TEntityDTO> : IAppServiceBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {

        protected readonly IMapper mapper;
        protected readonly IServiceBase<TEntity> service; // Domain Service

        public AppServiceBase(IMapper mapper, IServiceBase<TEntity> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public int Insert(TEntityDTO entityDTO)
        {
            // "Converte"/Mapeia um objeto DTO para Entity
            TEntity entity = mapper.Map<TEntity>(entityDTO);

            // Chama o Domain Service
            return service.Insert(entity);
        }

        public void Update(TEntityDTO entityDTO)
        {
            service.Update(mapper.Map<TEntity>(entityDTO));
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Delete(TEntityDTO entityDTO)
        {
            service.Delete(mapper.Map<TEntity>(entityDTO));
        }

        public TEntityDTO GetById(int id)
        {
            return mapper.Map<TEntityDTO>(service.GetById(id));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return mapper.Map<IEnumerable<TEntityDTO>>(service.GetAll());
        }

    }
}
