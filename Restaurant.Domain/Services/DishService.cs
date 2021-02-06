using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Interfaces.Services;

namespace Restaurant.Domain.Services
{
    class DishService<Entity> : ServiceBase<Dish>, IDishService
    {
        public DishService(IDishRepository repository) : base(repository)
        {

        }
    }
}
