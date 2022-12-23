using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BLL.Models
{
    public class OrderModel
    {
        private int id { get; set; }
        private int cost { get; set; }
        private int status { get; set; }
        private System.DateTime date { get; set; }
        private int waiterId_FK { get; set; }

        private int tableId_FK { get; set; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public System.DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int WaiterId_FK
        {
            get { return waiterId_FK; }
            set { waiterId_FK = value; }
        }
        public int TableId_FK
        {
            get { return tableId_FK; }
            set { tableId_FK = value; }
        }
        public OrderModel(Order order)
        {
            id = order.Id;
            cost = order.cost;
            status = order.status;
            date = order.date;
            waiterId_FK = 1;
            tableId_FK = order.tableId_FK;
        }

        public OrderModel()
        {
        }

        public ObservableCollection<OrderLineModel> orderLines;
    }
}
