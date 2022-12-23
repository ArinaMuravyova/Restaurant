using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DAL.Interfaces;
using BLL.Model;
using BLL.Interfaces;
using BLL.Models;
using DAL;

namespace Restaurant
{
    public class DbDataOperations:IDbCrud
    {
        IDbRepository db;

        public DbDataOperations(IDbRepository dbContext)
        {
            this.db = dbContext;
        }

        public ObservableCollection<DishModel> GetDishes()
        {
            List<DishModel> list;
            list = db.Dishes.GetList().Select(i => new DishModel(i)).ToList();
            return new ObservableCollection<DishModel>(list);
        }
        public ObservableCollection<WaiterModel> GetWaiters()
        {
            List<WaiterModel> list;
            list = db.Waiters.GetList().Select(i => new WaiterModel(i)).ToList();
            return new ObservableCollection<WaiterModel>(list);
        }
        public ObservableCollection<TableModel> GetTables()
        {
            List<TableModel> list;
            list = db.Tables.GetList().Select(i => new TableModel(i)).ToList();
            return new ObservableCollection<TableModel>(list);
        }
        public DishModel GetDish(int id)
        {
            return new DishModel(db.Dishes.GetItem(id));
        }
        public WaiterModel GetWaiter(int id)
        {
            return new WaiterModel(db.Waiters.GetItem(id));
        }
        public TableModel GetTable(int id)
        {
            return new TableModel(db.Tables.GetItem(id));
        }
        public void UpdateDish(int id)
        {

        }

        public ObservableCollection<CategoryModel> GetCategories()
        {
            List<CategoryModel> list;
            list = db.Categories.GetList().Select(i => new CategoryModel(i)).ToList();
            return new ObservableCollection<CategoryModel>(list);
        }
        public ObservableCollection<OrderLineStatusModel> GetOrderLineStatuses()
        {
            List<OrderLineStatusModel> list;
            list = db.OrderLineStatuses.GetList().Select(i => new OrderLineStatusModel(i)).ToList();
            return new ObservableCollection<OrderLineStatusModel>(list);
        }
        public ObservableCollection<OrderStatusModel> GetOrderStatuses()
        {
            List<OrderStatusModel> list;
            list = db.OrderStatuses.GetList().Select(i => new OrderStatusModel(i)).ToList();
            return new ObservableCollection<OrderStatusModel>(list);
        }
        public ObservableCollection<OrderModel> GetOrders()
        {
            List<OrderModel> list;
            list = db.Orders.GetList().Select(i => new OrderModel(i)).ToList();
            return new ObservableCollection<OrderModel>(list);
        }
        public ObservableCollection<OrderLineModel> GetOrderLines()
        {
            List<OrderLineModel> list;
            list = db.OrderLines.GetList().Select(i => new OrderLineModel(i)).ToList();
            return new ObservableCollection<OrderLineModel>(list);
        }
        public OrderModel GetOrder(int id)
        {
            return new OrderModel(db.Orders.GetItem(id));
        }
        public void CreateOrder(OrderModel order)
        {
            db.Orders.Create(new Order()
            {
               
                cost=order.Cost,
                date=order.Date,
                status=order.Status,
                waiterId_FK=1,
                tableId_FK=order.TableId_FK,
                
            }) ;
            Save();
        }
        public void DeleteOrder(int id)
        {
            Order p = db.Orders.GetItem(id);
            if (p != null)
            {
                db.Orders.Delete(p.Id);
                Save();
            }
        }
        public void UpdateOrder(OrderModel order)
        {
            Order o = db.Orders.GetItem(order.Id);
            o.cost = order.Cost;
            o.date = order.Date;
            o.status = order.Status;
            o.waiterId_FK = order.WaiterId_FK;
            db.Orders.Update(o);
            Save();
        }
        public void UpdateTable(TableModel table)
        {
            Table t = db.Tables.GetItem(table.Id);
            t.isAvailable = table.IsAvailable;
            t.number = table.Number;
            db.Tables.Update(t);
            Save();
        }
        public void CreateOrderLine(OrderLineModel order)
        {
            db.OrderLines.Create(new OrderLine()
            {
                
                cost = order.Cost,
                amount = order.Amount,
                dishId_FK = order.Dish_id,
                orderId_FK=order.Order_id,
                status=order.Status
            }) ;
            Save();
        }
        public void DeleteOrderLine(int id)
        {
            OrderLine p = db.OrderLines.GetItem(id);
            if (p != null)
            {
                db.OrderLines.Delete(p.Id);
                Save();
            }
        }
        public void UpdateOrderLine(OrderLineModel order)
        {
            OrderLine o = db.OrderLines.GetItem(order.Id);
            o.cost = order.Cost;
            o.amount = order.Amount;
            o.dishId_FK = order.Dish_id;
            o.orderId_FK = order.Order_id;
            db.OrderLines.Update(o);
            Save();
        }
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
