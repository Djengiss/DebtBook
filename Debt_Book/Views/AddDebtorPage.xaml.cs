using Debt_Book.Services;
using Debt_Book.Viewmodels;

namespace Debt_Book.Views;

public partial class AddDebtorPage : ContentPage
{
    public AddDebtorPage(DebtDatabase debtDatabase)
    {
        InitializeComponent();
        BindingContext = new AddDebtorViewModel(debtDatabase);
    }
}