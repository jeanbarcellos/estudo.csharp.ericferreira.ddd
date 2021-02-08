using AutoMapper;
using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;

namespace Restaurant.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Dish, DishDTO>();
            CreateMap<DishDTO, Dish>();
        }
    }
}
