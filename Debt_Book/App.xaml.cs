using Debt_Book.Services;
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

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
