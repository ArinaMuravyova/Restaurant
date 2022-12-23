
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL;
using System.Windows.Controls;
using BLL.Models;
using BLL.Model;
using Restaurant.View;
using System.Windows;

namespace Restaurant.ViewModel
{ 
    
    public class AppViewModel : INotifyPropertyChanged
    {


        IDbCrud dbo;
        ISortDishService sortDishService;

        public DataGrid dataGridOrders;
        public ListBox listBoxDishes;
        public ComboBox tableComboBox;
        public TextBox sum;

        ObservableCollection<BLL.Model.DishModel> listDishes;
        ObservableCollection<CategoryModel> listCategories;
        ObservableCollection<OrderModel> listOrders;
        private ObservableCollection<OrderLineModel> listLines = new ObservableCollection<OrderLineModel>();
        private List<string> choseListDishes=new List<string>();

        private ObservableCollection<TableModel> tables = new ObservableCollection<TableModel>() ;

        public OrderModel order;


        private DishModel selectedDish;
        private TableModel selectedTable;
        private CategoryModel selectedCategory;
        private OrderLineModel selectedLine;
        private int orderSum;

        public ObservableCollection<TableModel> Tables
        {
            get { return tables; }
            set { tables = value;
                OnPropertyChanged("Tables");
            }

        }
        public List<string> ChoseListDishes
        {
            get { return choseListDishes; }
            set
            {
                choseListDishes = value;
            }
        }
        public int OrderSum
        {
            get { return orderSum; }
            set { orderSum = value;
                OnPropertyChanged("OrderSum");
            }
        }
        public DishModel SelectedDish
        {
            get { return selectedDish; }
            set
            {
                selectedDish = value;
                OnPropertyChanged("SelectedDish");
            }
        }
       public OrderLineModel SelectedLine
        {
            get { return selectedLine; }
            set
            {
                selectedLine = value;
                OnPropertyChanged("SelectedLine");
            }
        }
        public TableModel SelectedTable
        {
            get { return selectedTable; }
            set
            {
                selectedTable = value;
                OnPropertyChanged("SelectedTable");
            }
        }
       
        public CategoryModel SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public ObservableCollection<OrderLineModel> ListLines
        {
            get { return listLines; }
            set { listLines= value;
            OnPropertyChanged("ListLines");
            }
        }
        public ObservableCollection<CategoryModel> ListCategories
        {
            get { return listCategories; }
            set { listCategories = value;
                OnPropertyChanged("ListCategories");
                }
        }

        public AppViewModel(IDbCrud dbcrud, ISortDishService sortDish, ListBox listBox, ComboBox comboBox, DataGrid dataGrid, ComboBox tablesCBox, TextBox summa)
        {
            sum = summa;

            orderSum = 0;
            dbo = dbcrud;
            sortDishService = sortDish;
           
            LoadCategories(comboBox);
            LoadDishes(listBox);
            dataGridOrders = dataGrid;
            listBoxDishes = listBox;
            tableComboBox = tablesCBox;

            LoadFreeTables();
            OrderViewModel.orderIsPaid += GetNLoadFreeTables;
            //tableComboBox.ItemsSource = Tables;
            //tableComboBox.DisplayMemberPath = "number";
            //tableComboBox.SelectedValuePath = "Number";

        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {

                      try
                      {
                           var selectedDish = obj as DishModel;
                          //listLines.Add(orderLine);
                          //orderSum += orderLine.Cost;
                          //sum.Text = orderSum.ToString();

                          if (selectedDish != null&&choseListDishes.Contains(selectedDish.Name))
                          {

                              for (int i = 0; i < listLines.Count; i++)
                              {
                                  if (listLines[i].DishName == selectedDish.Name)
                                  {
                                      listLines[i].Amount++;
                                      listLines[i].Cost = listLines[i].Amount * selectedDish.Cost;
                                      orderSum += selectedDish.Cost;

                                  }
                              }
                          }
                          else
                          {
                              OrderLineModel orderLine = new OrderLineModel();
                              orderLine.Cost = selectedDish.Cost;
                              orderLine.DishName = selectedDish.Name;
                              orderLine.Dish_id = selectedDish.Id;
                              //orderLine.Order_id = order.Id;
                              orderLine.Amount = 1;

                              choseListDishes.Add(selectedDish.Name);
                              listLines.Add(orderLine);
                              orderSum += orderLine.Cost;

                          }
                          sum.Text = orderSum.ToString();

                          OnPropertyChanged("ListLines");
                          dataGridOrders.Items.Refresh();
                          dataGridOrders.ItemsSource = listLines;

                      }
                      catch(Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                      }, (obj) => (selectedTable != null && selectedTable.IsAvailable == 1)));
            
            }
        }
        private RelayCommand removeLineCommand;
        public RelayCommand RemoveLineCommand
        {
            get
            {
                return removeLineCommand ??
                  (removeLineCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          int line_id = (dataGridOrders.SelectedItem as OrderLineModel).Dish_id;
                          OrderLineModel orderLine = (from l in listLines where l.Dish_id == line_id select l).SingleOrDefault();
                          listLines.Remove(orderLine);
                          choseListDishes.Remove(orderLine.DishName);
                          orderSum -= orderLine.Cost;
                          sum.Text = orderSum.ToString();
                          dataGridOrders.ItemsSource = listLines;
                      }
                      catch
                      {
                          MessageBox.Show("Выберете строку заказа!");
                      }
                     
                  },
               
                (obj) => (listLines.Count>0)));
            }
        }
        private RelayCommand loadDishByCategoryCommand;
        public RelayCommand LoadDishByCategoryCommand
        {
            get
            {
                return loadDishByCategoryCommand ??
                  (loadDishByCategoryCommand = new RelayCommand(obj =>
                  {
                  listDishes = sortDishService.SortDishByCategory(selectedCategory.Id);
                  listBoxDishes.ItemsSource = listDishes;
                  }));
            }
        }
        private RelayCommand startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand(obj =>
                  {
                      //OrderModel order = new OrderModel();
                  }));
            }
        }
        private RelayCommand switchOnOrdersPageCommand;
        public RelayCommand SwitchOnOrdersPageCommand
        {
            get
            {
                return switchOnOrdersPageCommand ??
                  (switchOnOrdersPageCommand = new RelayCommand(obj =>
                  {
                      Orders ordersWindow = new Orders();
                      ordersWindow.Show();
                  }));
            }
        }
       
        private RelayCommand makeOrderCommand;
        public RelayCommand MakeOrderCommand
        {
            get
            {
                return makeOrderCommand ??
                  (makeOrderCommand = new RelayCommand(obj =>
                  {
                      ObservableCollection<OrderStatusModel> orderStatuses = dbo.GetOrderStatuses();
                      ObservableCollection<OrderLineStatusModel> orderLineStatuses = dbo.GetOrderLineStatuses();

                      OrderModel order = new OrderModel();
                      order.Date = DateTime.Now;
                      order.Cost = orderSum;
                      order.Status = orderStatuses[0].Id;
                      order.orderLines = listLines;
                      order.TableId_FK = selectedTable.Id;
                      dbo.CreateOrder(order);

                     int lastItem = dbo.GetOrders().Last().Id;
                     // n_id++;
                      foreach (OrderLineModel i in listLines)
                      {

                         
                          i.Order_id = lastItem;
                          i.Status = orderLineStatuses[0].Id;
                          dbo.CreateOrderLine(i);
                         
                      }
                      
                      listLines.Clear();
                      choseListDishes.Clear();
                      orderSum = 0;
                      sum.Text = orderSum.ToString();
                      MessageBox.Show("Заказ успешно оформлен!");
                      selectedTable.IsAvailable = 0;
                      dbo.UpdateTable(SelectedTable);
                      LoadFreeTables();
                      Orders ordersWindow = new Orders();
                      ordersWindow.Show();
                  }, (obj) => (listLines.Count > 0)));
            } 
        }


        private RelayCommand increaseCommand;
        public RelayCommand IncreaseCommand
        {
            get
            {
                return increaseCommand ??
                  (increaseCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                         // OrderLineModel orderLine1 = obj as OrderLineModel;
                          //if (orderLine1 != null)
                          //{
                              int line_id = (dataGridOrders.SelectedItem as OrderLineModel).Dish_id;

                              OrderLineModel orderLine = (from l in listLines where l.Dish_id == line_id select l).SingleOrDefault();
                              orderLine.Amount++;
                              DishModel selDish = dbo.GetDish(orderLine.Dish_id);
                              orderLine.Cost = orderLine.Amount * selDish.Cost;
                              orderSum += selDish.Cost;
                              sum.Text = orderSum.ToString();
                              dataGridOrders.Items.Refresh();
                          //}
                      }
                      catch
                      {
                          MessageBox.Show("Выберете строку заказа!");
                         // MessageBox.Show(ex.Message);
                      }
                  },(obj)=> (listLines.Count > 0)));
            }
        }
        private RelayCommand decreaseCommand;
        public RelayCommand DecreaseCommand
        {
            get
            {
                return decreaseCommand ??
                  (decreaseCommand = new RelayCommand(obj =>
                  {
                      int line_id = (dataGridOrders.SelectedItem as OrderLineModel).Dish_id;
                      OrderLineModel orderLine = (from l in listLines where l.Dish_id == line_id select l).SingleOrDefault();
                      orderLine.Amount--;
                      DishModel selDish = dbo.GetDish(orderLine.Dish_id);
                      orderLine.Cost = orderLine.Amount * selDish.Cost;
                      orderSum -= selDish.Cost;
                      sum.Text = orderSum.ToString();
                      dataGridOrders.Items.Refresh();
                  },(obj)=>((dataGridOrders.SelectedItem as OrderLineModel)!=null&&((dataGridOrders.SelectedItem as OrderLineModel).Amount>1))));
                  
            }
        }
        private  void LoadCategories(ComboBox comboBox){
            listCategories = dbo.GetCategories();
            comboBox.ItemsSource = listCategories;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedValuePath = "Id";
         
          
        }
        private void LoadDishes(ListBox listBox)
        {
            listDishes = dbo.GetDishes();
           // selectedCategory.Id= 1;
          // listDishes = sortDishService.SortDishByCategory(selectedCategory.Id);
            listBox.ItemsSource = listDishes;
        }
        public  void LoadFreeTables()
        {
            var sortTables = dbo.GetTables().Where(i => i.IsAvailable == 1).ToList();
            Tables = new ObservableCollection<TableModel>(sortTables);
        }
        private void GetNLoadFreeTables(TableModel tableModel)
        {
            dbo.UpdateTable(tableModel);
            var sortTables = dbo.GetTables().Where(i => i.IsAvailable == 1).ToList();
            Tables = new ObservableCollection<TableModel>(sortTables);
        }
        private RelayCommand popDishWinCommand;
        public RelayCommand PopDishWinCommand
        {
            get
            {
                return popDishWinCommand ??
                  (popDishWinCommand = new RelayCommand(obj =>
                  {
                      PopularDishes PDWindow = new PopularDishes();
                      PDWindow.Show();
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
