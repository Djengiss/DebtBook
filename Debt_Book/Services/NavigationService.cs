using Debt_Book.Viewmodels;
using Debt_Book.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Book.Services
{
    public class NavigationService : INavigationService
    {
        public Task InitializeAsync() { return Task.CompletedTask; }

        public async Task NavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters = null) where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(AddDebtorViewModel))
            {
                await Shell.Current.GoToAsync(nameof(AddDebtorPage));
            }
            else if (typeof(TViewModel) == typeof(DebtorDetailsViewModel))
            {
                await Shell.Current.GoToAsync(nameof(DebtorDetailsPage));
            }
            else if (typeof(TViewModel) == typeof(MainViewModel)) 
            { 
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
        }

        public async Task PopAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
