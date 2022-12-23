using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepository
    {
        IRepository<Dish> Dishes { get; }
        ISortDishRepository SortDish { get; }
        IRepository<Category> Categories { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderLine> OrderLines { get; }
        IRepository<OrderLineStatus> OrderLineStatuses {get; }
        IRepository<OrderStatus> OrderStatuses { get; }
        IRepository<Table> Tables { get; }
        IRepository<Waiter> Waiters { get; }
        IPopularDishes PopularDishes { get; }
        int Save();
    }
}
