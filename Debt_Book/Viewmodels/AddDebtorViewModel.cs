using Debt_Book.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// Responsible for providing data and logic for the AddDebtorPage.xaml.
// Handles interactions and data binding for the add debtor page.
namespace Debt_Book.Viewmodels
{
    internal class AddDebtorViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        public string Name
        {
            get => _name; 
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }

        }

        private double _initialValue;
        public double InitialValue
        {
            get => _initialValue;
            set
            {
                _initialValue = value;
                OnPropertyChanged(nameof(InitialValue));
            }
        }

        public ICommand SaveDebtCommand { get; set; }
        public ICommand CancelCommand { get; set;}

        public AddDebtorViewModel()
        {
            SaveDebtCommand = new Command(async () => await SaveDebt());
            CancelCommand = new Command(async () => await ClearInput());
        }

        private async Task SaveDebt()
        {
            if (!string.IsNullOrEmpty(Name) && InitialValue > 0)
            {
                
            }
            else
            { 
                // Trigger any UI bound to ErrorMessage to update, perhaps showing an alert or message box.
            }      
        }

        private async Task ClearInput()
        {
            Name = string.Empty;
            InitialValue = 0;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public async Task AddNewDebtor()
        //{
        //    var debtor = new Debtor
        //    {
        //        AmountOwed = DebtorOwn,
        //        Name = DebtorName
        //    };
        //    var inserted = await _database.AddDebt(debt);
        //    if (inserted != 0)
        //    {
        //        Debtor.Add(debt);
        //        NewTodoTitle = String.Empty;
        //        NewTodoDue = DateTime.Now;
        //        RaisePropertyChanged(nameof(NewTodoDue), nameof(NewTodoTitle));
        //    }
        //}
    }
}
