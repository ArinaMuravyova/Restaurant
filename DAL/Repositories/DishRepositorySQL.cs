using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DishRepositorySQL:IRepository<Dish>
    {
        private RestaurantEntities db;
        public DishRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);
        }
        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
            {
                db.Dishes.Remove(dish);
            }
        }
        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }
        public List<Dish> GetList()
        {
            return db.Dishes.ToList();
        }
        public Dish GetItem(int id)
        {
            return db.Dishes.Find(id);
        }
    }
}
