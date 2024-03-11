namespace Debt_Book
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
        }
    }
}
