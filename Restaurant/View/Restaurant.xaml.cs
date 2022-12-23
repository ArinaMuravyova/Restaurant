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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using BLL.Interfaces;
using BLL.Util;
using Restaurant.Utils;
using Ninject;
//using System.Windows.Interactivity.dll;

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RestaurantWindow : Window
    {
        //List<Dish> Dishes;
       // IDbCrud dbo;
        public RestaurantWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("RestaurantEntities"));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            ISortDishService sortDishServ = kernel.Get<ISortDishService>();

            InitializeComponent();
            DataContext = new AppViewModel(crudServ, sortDishServ,menu,categories,dataGridOrder,tables,sum);
            
            
        }

       
    }
}
