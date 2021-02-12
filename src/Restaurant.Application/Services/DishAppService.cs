using AutoMapper;
using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Services;

namespace Restaurant.Application.Services
{
    public class DishAppService : AppServiceBase<Dish, DishDTO>, IDishAppService
    {
        public DishAppService(IMapper mapper, IServiceBase<Dish> service) : base(mapper, service)
        {
        }
    }
}
