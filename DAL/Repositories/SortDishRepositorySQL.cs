using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SortDishRepositorySQL:ISortDishRepository
    {
        private RestaurantEntities db;
        public SortDishRepositorySQL(RestaurantEntities restaurantEntities)
        {
            db = restaurantEntities;
        }
        public ObservableCollection<Dish> SortDishByCategory(int _categoryId)
        {
            var dishes = db.Dishes
                 .Where(i => i.categoryId == _categoryId)
                 .ToList();
            return new ObservableCollection<Dish>(dishes);
        }
    }
}
