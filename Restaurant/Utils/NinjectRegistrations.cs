using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Ninject.Modules;
using BLL.Services;

namespace Restaurant.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
           
            Bind<IDbCrud>().To<DbDataOperations>();
            Bind<ISortDishService>().To<SortDishService>();
            Bind<IPopularDishService>().To<PopularDishesService>();
        }
    }
}
