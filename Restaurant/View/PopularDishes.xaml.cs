using BLL.Interfaces;
using BLL.Util;
using Ninject;
using Restaurant.Utils;
using Restaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для PopularDishes.xaml
    /// </summary>
    public partial class PopularDishes : Window
    {
        public PopularDishes()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("RestaurantEntities"));
            IDbCrud crudServ = kernel.Get<IDbCrud>();
            ISortDishService sortDishServ = kernel.Get<ISortDishService>();
            IPopularDishService popularDishService = kernel.Get<IPopularDishService>();
            InitializeComponent();
            DataContext = new PopularDishesViewModel(crudServ, sortDishServ, popularDishService);
        }
    }
}
