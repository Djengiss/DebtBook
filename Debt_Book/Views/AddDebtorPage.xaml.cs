using Debt_Book.Viewmodels;

namespace Debt_Book.Views;

public partial class AddDebtorPage : ContentPage
{
	public AddDebtorPage()
	{
		InitializeComponent();
		BindingContext = new AddDebtorViewModel();
	}

}