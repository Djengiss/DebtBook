using Debt_Book.Viewmodels;

namespace Debt_Book.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
        Task PopAsync();
    }
}
