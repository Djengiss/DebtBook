using Debt_Book.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Debt_Book.Viewmodels
{
    internal class MainViewModel : ViewModelBase
    {
        
        public ICommand AddNewDebtorCommand { get; set; }
        public ICommand ViewDebtorInfoCommand { get; set; }

        public MainViewModel()
        {
            AddNewDebtorCommand = new Command(async () => await AddDebtor());
            ViewDebtorInfoCommand = new Command(async () => await ViewDebtorInfo());
        }

        private async Task AddDebtor()
        {
            await Navigation.PushAsync(new AddDebtorPage());
        }

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
