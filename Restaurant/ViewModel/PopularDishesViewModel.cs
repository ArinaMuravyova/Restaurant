using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModel
{
    public class PopularDishesViewModel: INotifyPropertyChanged
    {
        IDbCrud dbo;
        ISortDishService sortDishService;
        IPopularDishService popularDishService;

        private ObservableCollection<PopularDishModel> listPopularDishes;
        private DateTime? date_1;
        private DateTime? date_2;
        private ObservableCollection<CategoryModel> listCategories;
        private CategoryModel category;

        public CategoryModel Category
        {
            get { return category; }
            set { category = value;
                }
        }
        public DateTime? Date_1
        {
            get { return date_1; }
            set { date_1 = value;
                OnPropertyChanged("Date_1");
            }
        }
        public DateTime? Date_2
        {
            get { return date_2; }
            set
            {
                date_2 = value;
                OnPropertyChanged("Date_2");
            }
        }
        public ObservableCollection<PopularDishModel> ListPopularDishes
        {
            get { return listPopularDishes; }
            set
            {
                listPopularDishes = value;
                OnPropertyChanged("ListPopularDishes");
            }
        }
        public ObservableCollection<CategoryModel> ListCategories
        {
            get { return listCategories; }
            set
            {
                listCategories = value;
                OnPropertyChanged("ListCategories");
            }
        }
        public PopularDishesViewModel(IDbCrud dbcrud, ISortDishService sortDish,IPopularDishService dishService)
        {
            dbo = dbcrud;
            sortDishService = sortDish;
            popularDishService = dishService;
            ListCategories = dbo.GetCategories();
            //Date_1 = DateTime.Today;
            //Date_2 = DateTime.Today;
        }
        private RelayCommand findCommand;
        public RelayCommand FindCommand
        {
            get
            {
                return findCommand ??
                  (findCommand = new RelayCommand(obj =>
                  {
                      ListPopularDishes = popularDishService.PopularDishes(Date_1, Date_2);
                      if (category!=null)
                      {
                          ListPopularDishes = new ObservableCollection<PopularDishModel>(listPopularDishes.Where(i => i.CategoryId == category.Id));
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
