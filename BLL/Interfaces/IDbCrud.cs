
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        //void CreateDish(DishModel dish);
        //void DeleteDish(int id);
        //void UpdateDish(DishModel dish);
        ObservableCollection<DishModel> GetDishes();
        DishModel GetDish(int id);
        ObservableCollection<CategoryModel> GetCategories();
        ObservableCollection<OrderLineStatusModel> GetOrderLineStatuses();
        ObservableCollection<OrderStatusModel> GetOrderStatuses();
        ObservableCollection<OrderModel> GetOrders();
        ObservableCollection<OrderLineModel> GetOrderLines();
        ObservableCollection<TableModel> GetTables();
        ObservableCollection<WaiterModel> GetWaiters();
        WaiterModel GetWaiter(int id);
        TableModel GetTable(int id);
        OrderModel GetOrder(int id);
        void CreateOrder(OrderModel order);
        void DeleteOrder(int id);
        void UpdateOrder(OrderModel order);
        void UpdateTable(TableModel table);
        void CreateOrderLine(OrderLineModel orderLine);
        void UpdateOrderLine(OrderLineModel orderLine);
        void DeleteOrderLine(int id);
        

       
    }
}
