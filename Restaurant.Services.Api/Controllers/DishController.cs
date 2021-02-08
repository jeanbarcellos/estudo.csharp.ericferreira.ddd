using Restaurant.Application.DTO;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Services.Api.Controllers
{
    public class DishController : ControllerBase<Dish, DishDTO>
    {
        public DishController(IDishApp app) : base(app)
        {

        }
    }
}
