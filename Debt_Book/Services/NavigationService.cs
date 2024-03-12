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
        private readonly Dictionary<Type, Type> _mappings;
        
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            _mappings[typeof(MainViewModel)] = typeof(MainPage);
            _mappings[typeof(DebtorDetailsViewModel)] = typeof(DebtorDetailsPage);
            _mappings[typeof(AddDebtorViewModel)] = typeof(AddDebtorPage);
        }

        public async Task NavigateToAsync<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase 
        {
            Type pageType = _mappings[typeof(TViewModel)];
            Page page = (Page)Activator.CreateInstance(pageType);
            if (page != null)
            {
                
                page.BindingContext = viewModel;

                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }
     

        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
