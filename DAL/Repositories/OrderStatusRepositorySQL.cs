using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderStatusRepositorySQL:IRepository<OrderStatus>
    {
        private RestaurantEntities db;
        public OrderStatusRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(OrderStatus orderStatus)
        {
            db.OrderStatuses.Add(orderStatus);
        }
        public void Delete(int id)
        {
            OrderStatus orderStatus = db.OrderStatuses.Find(id);
            if (orderStatus != null)
            {
                db.OrderStatuses.Remove(orderStatus);
            }
        }
        public void Update(OrderStatus orderStatus)
        {
            db.Entry(orderStatus).State = EntityState.Modified;
        }
        public List<OrderStatus> GetList()
        {
            return db.OrderStatuses.ToList();
        }
        public OrderStatus GetItem(int id)
        {
            return db.OrderStatuses.Find(id);
        }
    }
}
