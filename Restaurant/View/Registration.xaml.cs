using BLL.Util;
using Ninject;
using Restaurant.Utils;
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
using BLL.Interfaces;
using Restaurant.ViewModel;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("RestaurantEntities"));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            InitializeComponent();
            DataContext = new RegistrationViewModel(crudServ);

        }
    }
}
