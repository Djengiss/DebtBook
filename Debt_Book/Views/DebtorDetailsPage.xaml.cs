
using Debt_Book.Viewmodels;

using Debt_Book.Models;

namespace Debt_Book.Views;

public partial class DebtorDetailsPage : ContentPage
{
	public DebtorDetailsPage(Debtor selectedDebtor)
	{
		InitializeComponent();
        BindingContext = new DebtorDetailsViewModel(selectedDebtor);
    }
}