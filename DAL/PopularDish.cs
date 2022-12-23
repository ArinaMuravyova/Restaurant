using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PopularDish
    {
        private int id, count,cost, categoryId;
        private string name;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
