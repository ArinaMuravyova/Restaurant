using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class OrderLineModel
    {
        private int amount,cost,dish_id,order_id,status;
        private string dishName;
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;

            }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public string DishName
        {
            get { return dishName; }
            set {  dishName=value; }
        }
        [Browsable(false)]
        [ReadOnly(true)]
        public int Dish_id {
            get { return dish_id; }
            set {  dish_id= value ; }
        }
        [Browsable(false)]
        [ReadOnly(true)]
        public int Order_id {
            get { return order_id; }
            set {  order_id= value ; }
        }
        public OrderLineModel(OrderLine order)
        {
            id = order.Id;
            amount = order.amount;
            cost = order.cost;
            dishName = order.Dish.name;
            dish_id = order.dishId_FK;
            order_id = order.orderId_FK;
            status = order.status;
        }

        public OrderLineModel()
        {
        }
    }
}
