using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Media;

using System.Windows;
//using Microsoft.WindowsAPICodePack.Dialogs;


namespace Restaurant.ViewModel
{
    public delegate void OrderIsPaid(TableModel table);
    public class OrderViewModel : INotifyPropertyChanged
    {

        IDbCrud dbo;

        private OrderLineModel selectedLine;
        private OrderModel selectedOrder;
        private int sum;
        ObservableCollection<OrderModel> listOrders;
        ObservableCollection<OrderLineModel> selectedOrderLines=new ObservableCollection<OrderLineModel>();
        
        public static event OrderIsPaid orderIsPaid;
       
        public OrderLineModel SelectedLine
        {
            get { return selectedLine; }
            set
            {
                selectedLine = value;
                OnPropertyChanged("SelectedLine");
            }
        }
        public ObservableCollection<OrderLineModel> SelectedOrderLines
        {
            get { return selectedOrderLines; }
            set
            {
                selectedOrderLines = value;
                OnPropertyChanged("SelectedOrderLines");
            }
        }
        public int Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
                if (selectedOrder != null)
                {
                    var list = dbo.GetOrderLines().Where(i => i.Order_id == selectedOrder.Id).ToList();
                    SelectedOrderLines = new ObservableCollection<OrderLineModel>(list);
                    Sum = selectedOrder.Cost;
                }
                else
                {
                    SelectedOrderLines.Clear();
                    Sum = 0;
                }

            }
        }
        public ObservableCollection<OrderModel> ListOrders
        {
            get { return listOrders; }
            set
            {
                listOrders = value;
                OnPropertyChanged("ListOrders");
            }
        }
        public OrderViewModel(IDbCrud dbCrud)
        {
            dbo = dbCrud;
            ListOrders = LoadOrders();
           
            
        }
        private ObservableCollection<OrderModel> LoadOrders()
        {
            listOrders = dbo.GetOrders();
            var newlistOrders = listOrders.Where(i => i.Status ==1);
             return new ObservableCollection<OrderModel>(newlistOrders);
           
        }

        private RelayCommand switchOnOrderStatus;
        public RelayCommand SwitchOnOrderStatus
        {
            get
            {
                return switchOnOrderStatus ??
                  (switchOnOrderStatus = new RelayCommand(obj =>
                  {
                      selectedOrder.Status = 2;
                       dbo.UpdateOrder(selectedOrder);
                     //ListOrders= LoadOrders();
                      MessageBox.Show("Заказ успешно оплачен!");
                      TableModel table = dbo.GetTable(selectedOrder.TableId_FK);
                      table.IsAvailable = 1;
                     // dbo.UpdateTable(table);
                      orderIsPaid(table);
                     
                  },(obj)=>(SelectedOrder != null && selectedOrder.Status==1)));
            }
        }
        private RelayCommand selectedOrderCommand;
        public RelayCommand SelectedOrderCommand
        {
            get
            {
                return selectedOrderCommand ??
                  (selectedOrderCommand = new RelayCommand(obj =>
                  {
                      var list = dbo.GetOrderLines().Where(i => i.Order_id == selectedOrder.Id);
                      SelectedOrderLines = new ObservableCollection<OrderLineModel>(list);

                  }));
            }
        }
        private RelayCommand saveCheckCommand;
        public RelayCommand SaveCheckCommand
        {
            get
            {
                return saveCheckCommand ??
                  (saveCheckCommand = new RelayCommand(obj =>
                  {
                      var list = dbo.GetOrderLines().Where(i => i.Order_id == selectedOrder.Id);
                      SelectedOrderLines = new ObservableCollection<OrderLineModel>(list);
                  string link = @"C:\Users\---\source\repos\RestaurantNew23.12.2022\Чеки";


                  //var dialog = new System.Windows.Forms.FolderBrowserDialog();
                  //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  //{
                  //    Utils.PDFWriter.WriteCheck(selectedOrder, selectedOrderLines, dialog.SelectedPath + Path.DirectorySeparatorChar + "Заказ_" + selectedOrder.Id + ".pdf");
                  Utils.PDFWriter.WriteCheck(selectedOrder, selectedOrderLines, link +Path.DirectorySeparatorChar + "Заказ_" + selectedOrder.Id + ".pdf");

                      MessageBox.Show("Успешно!");
                    // }
                      ListOrders = LoadOrders();

                  }, (obj)=>(selectedOrder!=null&&selectedOrder.Status==2)));
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
