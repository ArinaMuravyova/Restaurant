using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BLL.Model;


namespace Restaurant.Model
{
    //public class DishModel : INotifyPropertyChanged
    //{
    //    private string name, category;
    //    private int cost, id;

    //    public int Id
    //    {
    //        get
    //        {
    //            return id;
    //        }
    //        set
    //        {
    //            id = value;
    //            OnPropertyChanged("Name");
    //        }
    //    }
    //    public string Name
    //    {
    //        get
    //        {
    //            return name;
    //        }
    //        set
    //        {
    //            name = value;
    //            OnPropertyChanged("Name");
    //        }
    //    }
    //    public int Cost
    //    {
    //        get
    //        {
    //            return cost;
    //        }
    //        set
    //        {
    //            cost = value;
    //            OnPropertyChanged("Cost");
    //        }
    //    }
    //    public string Category
    //    {
    //        get
    //        {
    //            return category;
    //        }
    //        set
    //        {
    //            category = value;
    //            OnPropertyChanged("Category");
    //        }
    //    }

    //    public DishModel(BLL.Model.DishModel dish)
    //    {
    //        id = dish.Id;
    //        cost = dish.Cost;
    //        name = dish.Name;
    //        category = dish.Category;
    //    }

    //    public DishModel()
    //    {
    //    }

    //    //public ObservableCollection<string> Category { get; set; }
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public void OnPropertyChanged(string prop = "")
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    //    }

    //}
}
