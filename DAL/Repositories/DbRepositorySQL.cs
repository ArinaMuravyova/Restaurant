using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DbRepositorySQL:IDbRepository
    {
        private RestaurantEntities db;
        private DishRepositorySQL dishReporitory;
        private CategoryRepositorySQL categoryRepositorySQL;
        private SortDishRepositorySQL sortDishRepositorySQL;
        private OrderLineRepositorySQL orderLineRepositorySQL;
        private OrderRepositorySQL orderRepositorySQL;
        private OrderLineStatusRepositorySQL orderLineStatusRepositorySQL;
        private OrderStatusRepositorySQL orderStatusRepositorySQL;
        private PopularDishRepository popularDishRepository;
        private TableRepositorySQL tableRepositorySQL;
        private WaiterRepositorySQL waiterRepositorySQL;

        public DbRepositorySQL()
        {
            db = new RestaurantEntities();
        }
        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishReporitory == null)
                dishReporitory = new DishRepositorySQL(db);
                    return dishReporitory;
                
            }
        }
        public IRepository<Waiter> Waiters
        {
            get
            {
                if (waiterRepositorySQL == null)
                    waiterRepositorySQL = new WaiterRepositorySQL(db);
                return waiterRepositorySQL;

            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepositorySQL == null)
                    categoryRepositorySQL = new CategoryRepositorySQL(db);
                return categoryRepositorySQL;

            }
        }
        public ISortDishRepository SortDish
        {
            get
            {
                if (sortDishRepositorySQL == null)
                    sortDishRepositorySQL = new SortDishRepositorySQL(db);
                return sortDishRepositorySQL;
                    
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepositorySQL == null)
                    orderRepositorySQL = new OrderRepositorySQL(db);
                return orderRepositorySQL;

            }
        }
        public IRepository<OrderLine> OrderLines
        {
            get
            {
                if (orderLineRepositorySQL == null)
                    orderLineRepositorySQL = new OrderLineRepositorySQL(db);
                return orderLineRepositorySQL;

            }
        }
        public IRepository<OrderLineStatus> OrderLineStatuses
        {
            get
            {
                if (orderLineStatusRepositorySQL == null)
                    orderLineStatusRepositorySQL = new OrderLineStatusRepositorySQL(db);
                return orderLineStatusRepositorySQL;

            }
        }
        public IRepository<OrderStatus> OrderStatuses
        {
            get
            {
                if (orderStatusRepositorySQL == null)
                    orderStatusRepositorySQL = new OrderStatusRepositorySQL(db);
                return orderStatusRepositorySQL;

            }
        }
        public IRepository<Table> Tables
        {
            get
            {
                if (tableRepositorySQL == null)
                    tableRepositorySQL = new TableRepositorySQL(db);
                return tableRepositorySQL;

            }
        }
        public IPopularDishes PopularDishes
        {
            get
            {
                if (popularDishRepository == null)
                    popularDishRepository = new PopularDishRepository(db);
                return popularDishRepository;

            }
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
