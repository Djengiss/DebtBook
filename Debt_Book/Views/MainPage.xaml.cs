using Debt_Book.Viewmodels;
using Debt_Book.Services;

namespace Debt_Book.Views;

public partial class MainPage : ContentPage
{   
    public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(NavigateToAddDebtorPage);
    }

    private void NavigateToAddDebtorPage()
    {
        Navigation.PushAsync(new AddDebtorPage(((MainViewModel)BindingContext).Database));
    }
}


