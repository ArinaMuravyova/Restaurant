using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WaiterRepositorySQL:IRepository<Waiter>
    {
        private RestaurantEntities db;
        public WaiterRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(Waiter waiter)
        {
            db.Waiters.Add(waiter);
        }
        public void Delete(int id)
        {
            Waiter waiter = db.Waiters.Find(id);
            if (waiter != null)
            {
                db.Waiters.Remove(waiter);
            }
        }
        public void Update(Waiter waiter)
        {
            db.Entry(waiter).State = EntityState.Modified;
        }
        public List<Waiter> GetList()
        {
            return db.Waiters.ToList();
        }
        public Waiter GetItem(int id)
        {
            return db.Waiters.Find(id);
        }
    }
}
