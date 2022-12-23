using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SortDishService:ISortDishService
    {
        IDbRepository db;
        public SortDishService(IDbRepository dbRepository)
        {
            db = dbRepository;
        }

        public ObservableCollection<DishModel> SortDishByCategory(int category_Id)
        {
            var groupDishes = db.SortDish.SortDishByCategory(category_Id)
                .Select(i=>new DishModel(i) {Id=i.Id,Cost=i.cost,Name=i.name,Category=i.Category.name }).ToList();
            return new ObservableCollection<DishModel>(groupDishes);
        }
    }
}
