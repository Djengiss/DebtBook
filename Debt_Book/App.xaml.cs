using Debt_Book.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Debt_Book
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
