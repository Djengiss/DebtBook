namespace Debt_Book
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
            Routing.RegisterRoute(nameof(Views.AddDebtorPage), typeof(Views.AddDebtorPage));
            Routing.RegisterRoute(nameof(Views.DebtorDetailsPage), typeof(Views.DebtorDetailsPage));
        }
    }
}
