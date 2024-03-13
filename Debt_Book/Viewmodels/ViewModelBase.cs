using Debt_Book.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Debt_Book.Viewmodels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged(params string[] properties)
        {
            foreach (var propertyName in properties)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region INavigationService
        public INavigationService NavigationService { get; set; }
        #endregion
    }
}
