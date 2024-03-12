﻿using Debt_Book.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Debt_Book.Models;
using Debt_Book;
using Debt_Book.Views;
using System.Collections.ObjectModel;

// Responsible for providing data and logic for the DebtorDetailsPage.xaml.
// Handles interactions and data binding for the debtor details page.
namespace Debt_Book.Viewmodels
{
    internal class DebtorDetailsViewModel : ViewModelBase
    {
        private Debtor _currentDebtor;
        public Debtor CurrentDebtor
        {
            get => _currentDebtor;
        }
        private string _currentPersonName;

        public string CurrentPersonName
        {
            get => _currentPersonName;
            set
            {
                _currentPersonName = value;
                OnPropertyChanged(nameof(CurrentPersonName));
            }
        }

        private ObservableCollection<Debt> _debts;
        public ObservableCollection<Debt> Debts
        {
            get => _debts;
            set
            {
                _debts = value;
                OnPropertyChanged(nameof(Debts));
            }
        }


        private readonly DebtDatabase _database;

        public ICommand ReturnCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddDebtCommand { get; }
        public ICommand AddCreditCommand { get; }
        public DebtorDetailsViewModel(Debtor selectedDebtor)
        {
            try
            {
                ReturnCommand = new Command(async () => await Return());
                CancelCommand = new Command(Cancel);
                AddDebtCommand = new Command(async () => await AddDebt());
                AddCreditCommand = new Command(async () => await AddCredit());
                _database = new DebtDatabase();
                CurrentPersonName = CurrentDebtor.Name;
                _ = LoadDebtsForCurrentDebtor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DebtorDetailsViewModel constructor");
            }
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

        private async Task AddDebt()
        {
            
            if (!string.IsNullOrEmpty(_currentPersonName) && Value > 0)
            {
                Debt newDebt = new Debt
                {
                    Amount = -Value,
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    DebtorId = _currentDebtor.Id,
                };
                int rowsAffected = await _database.AddDebt(newDebt);
            }
            else
            {
                return;
            }
        }

        private async Task AddCredit()
        {
            if (!string.IsNullOrEmpty(_currentPersonName) && Value > 0)
            {
                Debt newDebt = new Debt
                {
                    Amount = Value,
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    DebtorId = _currentDebtor.Id,
                };
                int rowsAffected = await _database.AddDebt(newDebt);
            }
            else
            {
                return;
            }
        }
        private async Task Return()
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void Cancel()
        {
            Value = 0;
        }
        private async Task<List<Debt>> GetDebts()
        {
            if (_currentDebtor != null)
            {
                return await _database.GetDebt(_currentDebtor.Id);
            }
            else
            {
                return new List<Debt>(); // Return an empty list if _currentDebtor is null
            }
        }
        private async Task LoadDebtsForCurrentDebtor()
        {
            Debts = new ObservableCollection<Debt>(await GetDebts());
        }
    }
}
