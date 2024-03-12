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
        public ICommand AddNewDebtorCommand { get; set; }
        public ICommand ViewDebtorInfoCommand { get; set; }
        private readonly DebtDatabase _database;
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _database = new DebtDatabase();
            AddNewDebtorCommand = new Command(async () => await AddDebtor());
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

        private async Task AddDebtor()
        {
            await _navigationService.NavigateToAsync<AddDebtorViewModel>();
        }

        //public void AddDebtor()
        //{
        //    var newAddDeptor = new Window(new AddDebtorPage(_database))
        //    {
        //        Title = "Add Debtor",
        //        Width = 800,
        //        Height = 1000
        //    };
        //    Application.Current.OpenWindow(newAddDeptor);
        //}

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
