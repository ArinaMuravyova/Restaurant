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
using System.Windows;

namespace Restaurant.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        IDbCrud dbo;
        private  ObservableCollection<WaiterModel> listWaiters;
        private string login;
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public RegistrationViewModel(IDbCrud dbCrud)
        {
            dbo = dbCrud;
        }
        private RelayCommand enterCommand;
        public RelayCommand EnterCommand
        {
            get
            {
                return enterCommand ??
                  (enterCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          var listLogin = dbo.GetWaiters().Select(i=>i.Login).ToList();
                          if (listLogin.Contains(login))
                          {
                              var list = dbo.GetWaiters().ToList();
                              foreach(WaiterModel l in list)
                              {
                                  if (l.Login == login&&l.Password==password)
                                  {
                                      int waiterId = l.Id;
                                     
                                      RestaurantWindow restaurant = new RestaurantWindow();
                                      restaurant.Show();
                                      break;
                                  }
                              }
                          }
                          else
                          {
                              MessageBox.Show("Неправильно введен Логин или Пароль!");
                          }
                      }
                      catch
                      {
                          MessageBox.Show("Введите повторно логин и пароль");
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
