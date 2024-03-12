﻿using Debt_Book.Models;
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
        private readonly INavigationService _navigationService;
        private readonly DebtDatabase _debtDatabase;

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddDebtorViewModel(INavigationService navigationService, DebtDatabase debtDatabase)
        {
            _navigationService = navigationService;
            _debtDatabase = debtDatabase;
            SaveCommand = new Command(async () => await SaveDebt());
            CancelCommand = new Command(async () => await CancelAndNavigateBack());

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

                ClearInputFields();

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
            await _navigationService.PopAsync();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
