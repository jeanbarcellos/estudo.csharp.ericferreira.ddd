using Restaurant.Application.DTO;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IDishAppService : IAppServiceBase<Dish, DishDTO>
    {

    }
}
