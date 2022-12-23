using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPopularDishes
    {
        ObservableCollection<PopularDish> PopularDishes(DateTime? data1,DateTime? data2);
    }
}
