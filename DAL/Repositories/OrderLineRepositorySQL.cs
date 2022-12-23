using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderLineRepositorySQL:IRepository<OrderLine>
    {
        private RestaurantEntities db;
        public OrderLineRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(OrderLine orderLine)
        {
            db.OrderLines.Add(orderLine);
        }
        public void Delete(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine != null)
            {
                db.OrderLines.Remove(orderLine);
            }
        }
        public void Update(OrderLine orderLine)
        {
            db.Entry(orderLine).State = EntityState.Modified;
        }
        public List<OrderLine> GetList()
        {
            return db.OrderLines.ToList();
        }
        public OrderLine GetItem(int id)
        {
            return db.OrderLines.Find(id);
        }
    }
}
