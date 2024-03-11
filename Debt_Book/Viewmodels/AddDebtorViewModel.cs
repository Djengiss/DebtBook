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

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set;}

        public AddDebtorViewModel()
        {
            SaveCommand = new Command(SaveDebt);
            CancelCommand = new Command(ClearInput);
        }

        private void SaveDebt()
        {
            if (!string.IsNullOrEmpty(Name) && InitialValue > 0)
            {
                // skal sendes til database
            }
            else
            { 
                // Trigger any UI bound to ErrorMessage to update, perhaps showing an alert or message box.
            }
        }

        private void ClearInput()
        {
            Name = string.Empty;
            InitialValue = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
