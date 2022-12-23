using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.Repositories
{
    public class CategoryRepositorySQL:IRepository<Category>
    {
        private RestaurantEntities db;
        public CategoryRepositorySQL(RestaurantEntities dbContext)
        {
            this.db = dbContext;
        }
        public void Create(Category category)
        {
            db.Categories.Add(category);
        }
        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
        }
        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }
        public List<Category> GetList()
        {
            return db.Categories.ToList();
        }
        public Category GetItem(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
