using Debt_Book.Models;
using Debt_Book.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private readonly Action<Debtor> _debtorAddedCallback;

        public ICommand AddDebtCommand { get; set; }
        public ICommand AddCreditCommand { get; set; }
        public ICommand CancelCommand { get; private set; }

        new public event PropertyChangedEventHandler PropertyChanged;

        public AddDebtorViewModel(INavigationService navigationService, DebtDatabase debtDatabase, Action<Debtor> debtorAddedCallback)
        {
            NavigationService = navigationService;
            _debtDatabase = debtDatabase;
            _debtorAddedCallback = debtorAddedCallback;
            AddCreditCommand = new Command(async () => await AddCredit());
            AddDebtCommand = new Command(async () => await AddDebt());
            CancelCommand = new Command(async () => await CancelAndNavigateBack());

        }

        private async Task AddDebt()
        {

            if (!string.IsNullOrEmpty(Name) && InitialValue > 0)
            {
                var debtor = new Debtor
                {
                    Name = Name
                };

                await _debtDatabase.AddDebtor(debtor);

                Debt newDebt = new Debt
                {
                    Amount = -InitialValue,
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    DebtorId = debtor.Id
                    
                };

                await _debtDatabase.AddDebt(newDebt);
                debtor.AmountOwed = await _debtDatabase.GetTotalDebtForDebtor(debtor.Id);
                _debtorAddedCallback?.Invoke(debtor);

                ClearInputFields();
                await NavigationService.PopAsync();
            }
            else
            {
                return;
            }
        }

        private async Task AddCredit()
        {

            if (!string.IsNullOrEmpty(Name) && InitialValue > 0)
            {
                var debtor = new Debtor
                {
                    Name = Name
                };

                await _debtDatabase.AddDebtor(debtor);

                Debt newDebt = new Debt
                {
                    Amount = InitialValue,
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    DebtorId = debtor.Id

                };

                await _debtDatabase.AddDebt(newDebt);
                debtor.AmountOwed = await _debtDatabase.GetTotalDebtForDebtor(debtor.Id);
                _debtorAddedCallback?.Invoke(debtor);

                ClearInputFields();
                await NavigationService.PopAsync();
            }
            else
            {
                return;
            }
        }
        private void ClearInputFields()
        {
            Name = string.Empty;
            InitialValue = 0;
        }

        private async Task CancelAndNavigateBack()
        {
            ClearInputFields();
            await NavigationService.PopAsync();
        }

        new protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
