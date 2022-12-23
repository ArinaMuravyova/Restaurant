using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class OrderRepositorySQL:IRepository<Order>
    {
        private RestaurantEntities db;
        public OrderRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
            }
        }
        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public List<Order> GetList()
        {
            return db.Orders.ToList();
        }
        public Order GetItem(int id)
        {
            return db.Orders.Find(id);
        }
    }
}
