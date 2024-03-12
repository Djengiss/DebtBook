using Debt_Book.Models;
using Debt_Book.Services;
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

        private readonly DebtDatabase _debtDatabase;

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public AddDebtorViewModel(DebtDatabase debtDatabase)
        {
            _debtDatabase = debtDatabase;
            SaveCommand = new Command(async () => await SaveDebt());
            CancelCommand = new Command(async () => await ClearInput());
        }

        private async Task SaveDebt()
        {
            if (!string.IsNullOrEmpty(Name) && InitialValue > 0)
            {

                var debtor = new Debtor
                {
                    Name = Name
                };

                await _debtDatabase.AddDebtor(debtor);

                var debt = new Debt
                {
                    DebtorId = debtor.Id,
                    Amount = InitialValue,
                };

                await _debtDatabase.AddDebt(debt);

                ClearInput();

            }
        }

        private void ClearInput()
        {
            Name = string.Empty;
            InitialValue = 0;
            
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
