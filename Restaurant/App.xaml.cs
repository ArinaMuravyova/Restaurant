using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using BLL.Interfaces;
using BLL.Util;
using Restaurant.Utils;
using Ninject;

namespace Restaurant
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("ТурагенствоEntities"));

            //IDbCrud crudServ = kernel.Get<IDbCrud>();
            //ISortDishService sortDishServ = kernel.Get<ISortDishService>();
            //DataContext = new AppViewModel(crudServ, sortDishServ, menu, categories);
        }
        private void ConfigureContainer()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("RestaurantEntities"));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            ISortDishService sortDishServ = kernel.Get<ISortDishService>();
        }
    }
}
