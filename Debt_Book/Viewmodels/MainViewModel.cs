using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Debt_Book.Models;
using Debt_Book.Services;

namespace Debt_Book.Viewmodels
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Debtor> Debtors { get; set; } = new();

        public ICommand ViewDebtorInfoCommand { get; set; }
        private readonly DebtDatabase _database;
      
        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            _database = new DebtDatabase();

            ViewDebtorInfoCommand = new Command<Debtor>(async (selecteddebtor) => await ViewDebtorInfo(selecteddebtor));
            _ = Initialize();
        }

        private async Task Initialize()
        {
            await LoadDebtors();
        }

        private async Task LoadDebtors()
        {
            Debtors.Clear();
            var debtors = await _database.GetDebtors();

            foreach (var debtor in debtors)
            {
                debtor.AmountOwed = await _database.GetTotalDebtForDebtor(debtor.Id);
                Debtors.Add(debtor);
            }
        }

        public ICommand AddNewDebtorCommand => new Command(async () =>
        {
            var addDebtorViewModel = new AddDebtorViewModel(NavigationService, _database, DebtorAddedCallback);
            await NavigationService.NavigateToAsync(addDebtorViewModel);
        });

        private void DebtorAddedCallback(Debtor newDebtor)
        {
            Debtors.Add(newDebtor);
        }

        private async void DebtModifiedCallback(Debtor debtor)
        {
            await LoadDebtors();
        }

        private async Task ViewDebtorInfo(Debtor selectedDebtor)
        {
            if (selectedDebtor != null)
            {
                var debtorDetailsViewModel = new DebtorDetailsViewModel(NavigationService, _database ,selectedDebtor, DebtModifiedCallback);
                await NavigationService.NavigateToAsync(debtorDetailsViewModel);
                
            }
            else
            {
                Console.WriteLine("no debtor selected");
            }
        }

        private Debtor _selectedDebtor;
        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            set
            {
                if (_selectedDebtor != value)
                {
                    _selectedDebtor = value;
                    OnPropertyChanged(nameof(SelectedDebtor));
                    ViewDebtorInfoCommand.Execute(_selectedDebtor);
                }
            }
        }

        new public event PropertyChangedEventHandler PropertyChanged;
        new protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
