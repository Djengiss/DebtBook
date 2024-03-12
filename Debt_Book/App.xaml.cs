using Debt_Book.Services;
using Debt_Book.Viewmodels;
using Debt_Book.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Debt_Book
{
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App()
        {
            InitializeComponent();

            _navigationService = new NavigationService();
            var mainViewModel = new MainViewModel(_navigationService);
            MainPage = new NavigationPage(new MainPage() { BindingContext = mainViewModel });
        }
    }
}
