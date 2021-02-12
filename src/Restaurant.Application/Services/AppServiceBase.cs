using AutoMapper;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Restaurant.Application.Services
{
    public class AppServiceBase<TEntity, TEntityDTO> : IAppServiceBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {
        protected readonly IMapper _mapper;
        protected readonly IServiceBase<TEntity> _service; // Domain Service

        public AppServiceBase(IMapper mapper, IServiceBase<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public int Insert(TEntityDTO entityDTO)
        {
            // "Converte"/Mapeia um objeto DTO para Entity
            TEntity entity = _mapper.Map<TEntity>(entityDTO);

            // Chama o Domain Service
            return _service.Insert(entity);
        }

        public void Update(TEntityDTO entityDTO)
        {
            _service.Update(_mapper.Map<TEntity>(entityDTO));
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public void Delete(TEntityDTO entityDTO)
        {
            _service.Delete(_mapper.Map<TEntity>(entityDTO));
        }

        public TEntityDTO GetById(int id)
        {
            return _mapper.Map<TEntityDTO>(_service.GetById(id));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntityDTO>>(_service.GetAll());
        }
    }
}
