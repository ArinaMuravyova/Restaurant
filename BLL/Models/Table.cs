using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class TableModel
    {
        private int id, number;
        private byte isAvailable;
        public int Id {
            get { return id; }
            set { id = value; } 
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public byte IsAvailable {
            get { return isAvailable; }
            set
            {
                isAvailable = value;
            }
        }
        public TableModel(Table table)
        {
            id = table.Id;
            number = table.number;
            isAvailable = table.isAvailable;
        }
    }
}
