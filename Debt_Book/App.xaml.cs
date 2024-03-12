using Debt_Book.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Debt_Book
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = serviceProvider.GetService<MainPage>();
        }
    }
}
