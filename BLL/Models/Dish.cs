using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DAL;

namespace BLL.Model
{
    public class DishModel
    {
        private string name, category;
        private int cost,id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
               // OnPropertyChanged("Name");
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
               // OnPropertyChanged("Name");
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
                //OnPropertyChanged("Cost");
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                //OnPropertyChanged("Category");
            }
        }

        public DishModel(Dish dish)
        {
            id = dish.Id;
            cost = dish.cost;
            name = dish.name;
            category = dish.Category.name;
        }

        public DishModel()
        {
        }
        //public ObservableCollection<string> Category { get; set; }
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged(string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}

    }
}
