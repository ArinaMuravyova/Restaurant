using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPopularDishService
    {
        ObservableCollection<PopularDishModel> PopularDishes(DateTime? data1, DateTime? data2);
    }
}
