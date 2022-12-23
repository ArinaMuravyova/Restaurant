using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public  class OrderStatusModel
    {
        private int id;
        private string name;

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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }
        public OrderStatusModel(OrderStatus orderStatus)
        {
            id = orderStatus.Id;
            name = orderStatus.name;

        }
    }

}
