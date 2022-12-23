using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PopularDishesService:IPopularDishService
    {
        IDbRepository db;
        public PopularDishesService(IDbRepository repos)
        {
            db = repos;
        }
        public ObservableCollection<PopularDishModel> PopularDishes(DateTime? data1,DateTime? data2)
        {
            var request = db.PopularDishes.PopularDishes(data1, data2)
             .Select(i => new PopularDishModel() { Name = i.Name, CategoryId = i.CategoryId, Cost= i.Cost,Count=i.Count}).ToList();
            return new ObservableCollection<PopularDishModel>(request);
        }
    }
}
