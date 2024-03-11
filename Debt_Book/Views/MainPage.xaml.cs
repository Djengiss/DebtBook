using Debt_Book.Viewmodels;

namespace Debt_Book.Views;

public partial class MainPage : ContentPage
{
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
}


