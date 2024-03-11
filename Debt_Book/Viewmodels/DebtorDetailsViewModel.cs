using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Responsible for providing data and logic for the DebtorDetailsPage.xaml.
// Handles interactions and data binding for the debtor details page.
namespace DebtBook.Viewmodels
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
