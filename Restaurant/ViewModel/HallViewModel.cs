using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restaurant.ViewModel
{
    public class HallViewModel:INotifyPropertyChanged
    {
        public  struct Table
        {
            public int number;
            public bool isAvailable;
        } 

        private Button selectedBtn;
        private Table selectedTable;
        public List<Button> btnList;

       
        public Table SelectedTable
        {
            get { return selectedTable; }
            set
            {
                selectedTable = value;
                OnPropertyChanged("SelectedTable");
            }
        }
        public Button SelectedBtn
        {
            get { return selectedBtn; }
            set
            {
                selectedBtn = value;
                OnPropertyChanged("SelectedBtn");
            }
        }
        public HallViewModel(List<Button> buttonList) 
        {
            btnList = buttonList;
        }
        private RelayCommand chooseTableCommand;
        public RelayCommand ChooseTableCommand
        {
            get
            {
                return chooseTableCommand ??
                  (chooseTableCommand = new RelayCommand(obj =>
                  {
                      selectedBtn.IsEnabled = false;
                      //if (btn.IsEnabled) {
                      //    btn.IsEnabled = false;
                      //    selectedBtn = btn;
                      //    }
                      //else
                      //{
                      //    btn.IsEnabled = true;
                      //}

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
