using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public  class OrderLineStatusRepositorySQL:IRepository<OrderLineStatus>
    {
        private RestaurantEntities db;
        public OrderLineStatusRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(OrderLineStatus orderLineStatus)
        {
            db.OrderLineStatuses.Add(orderLineStatus);
        }
        public void Delete(int id)
        {
            OrderLineStatus orderLineStatus = db.OrderLineStatuses.Find(id);
            if (orderLineStatus != null)
            {
                db.OrderLineStatuses.Remove(orderLineStatus);
            }
        }
        public void Update(OrderLineStatus orderLineStatus)
        {
            db.Entry(orderLineStatus).State = EntityState.Modified;
        }
        public List<OrderLineStatus> GetList()
        {
            return db.OrderLineStatuses.ToList();
        }
        public OrderLineStatus GetItem(int id)
        {
            return db.OrderLineStatuses.Find(id);
        }
    }
}
