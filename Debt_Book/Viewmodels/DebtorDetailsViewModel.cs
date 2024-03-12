using Debt_Book.Models;
using Debt_Book.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// Responsible for providing data and logic for the DebtorDetailsPage.xaml.
// Handles interactions and data binding for the debtor details page.
namespace Debt_Book.Viewmodels
{
    internal class DebtorDetailsViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            
        }

        private double _Value;
        public double Value
        {
            get => _Value;
            set
            {
                _Value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        private readonly INavigationService _navigationService;

        public DebtorDetailsViewModel(INavigationService navigationService, Debtor selectedDebtor)
        {
            _navigationService = navigationService;
        }

        private void AddDebt()
        {
            if (!string.IsNullOrEmpty(Name) && Value > 0)
            {
                // skal sendes til database
            }
            else
            {
                // Trigger any UI bound to ErrorMessage to update, perhaps showing an alert or message box.
            }
        }
    }
}
