using Debt_Book.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly INavigationService _navigationService;
       

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _database = new DebtDatabase();
            
            ViewDebtorInfoCommand = new Command(async () => await ViewDebtorInfo());
            _ = Initialize();
        }
        private async Task Initialize()
        {
            
            var debtors = await _database.GetDebtors();

            foreach(var debtor in debtors)
            {
                Debtors.Add(debtor);
            }
        }

        public ICommand AddNewDebtorCommand => new Command(async () =>
        {
            var addDebtorViewModel = new AddDebtorViewModel(_navigationService, _database);
            await _navigationService.NavigateToAsync(addDebtorViewModel);
        });

        private async Task ViewDebtorInfo()
        {
            await Navigation.PushAsync(new DebtorDetailsPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
