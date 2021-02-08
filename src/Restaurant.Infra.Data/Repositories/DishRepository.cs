using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Infra.Data.Contexts;

namespace Restaurant.Infra.Data.Repositories
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(Context context)
            : base(context)
        {

        }

    }
}
