using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PopularDishRepository:IPopularDishes
    {
        private RestaurantEntities db;
        public PopularDishRepository(RestaurantEntities restaurantEntities)
        {
            db = restaurantEntities;
        }
        public ObservableCollection<PopularDish> PopularDishes(DateTime? data1, DateTime? data2)
        {
            var ordersId = db.Orders.Where(i => i.date >= data1 && i.date <= data2).Select(i=>i.Id);
            var dishLines = db.OrderLines.Where(i => ordersId.Contains(i.orderId_FK)).GroupBy(item=>item.dishId_FK,item=>item.amount,(key,g)=>new { DishId = key, Sum = g.Sum() })
                .OrderByDescending(i=>i.Sum);// это список где ключ=dishId а значение=sum(кол-ву заказанных блюд) ,отсортированных по убыванию
            List<PopularDish> favDishes = new List<PopularDish>();
            List<Dish> alldishes = db.Dishes.ToList();
            foreach(var i in dishLines)
            {
                var dish = alldishes.Where(j => j.Id == i.DishId).ToList();
               favDishes.Add(new PopularDish { Name = dish[0].name, Cost = dish[0].cost, Count = i.Sum, CategoryId = dish[0].categoryId });
            }
            return new ObservableCollection<PopularDish>(favDishes);
        }
    }
}
