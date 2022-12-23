using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TableRepositorySQL:IRepository<Table>
    {
        private RestaurantEntities db;
        public TableRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(Table table)
        {
            db.Tables.Add(table);
        }
        public void Delete(int id)
        {
            Table table = db.Tables.Find(id);
            if (table != null)
            {
                db.Tables.Remove(table);
            }
        }
        public void Update(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
        }
        public List<Table> GetList()
        {
            return db.Tables.ToList();
        }
        public Table GetItem(int id)
        {
            return db.Tables.Find(id);
        }
    }
}
