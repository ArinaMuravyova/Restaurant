using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public  class OrderLineStatusModel
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
        public OrderLineStatusModel(OrderLineStatus orderLineStatus)
        {
            id = orderLineStatus.Id;
            name = orderLineStatus.name;

        }
    }
 }
