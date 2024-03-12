using Debt_Book.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Book.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>(string route, IDictionary<string, object> routeParameters = null) where TViewModel : ViewModelBase;
        Task PopAsync();
    }
}
