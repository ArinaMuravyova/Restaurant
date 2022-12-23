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
using Restaurant.ViewModel;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для RestaurantHall.xaml
    /// </summary>
    public partial class RestaurantHall : Window
    {
       
        public RestaurantHall()
        {
            InitializeComponent();
             List<Button> buttonNumberList = new List<Button>() { btn1, btn2, btn3, btn4, btn5 ,btn6, btn7 };
            DataContext = new HallViewModel(buttonNumberList);
        }

        
    }
}
