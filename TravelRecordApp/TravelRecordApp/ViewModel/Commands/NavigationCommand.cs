using System;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class NavigationCommand :ICommand
    {
        public HomeViewModel HomeVm { set; get; }
        public event EventHandler CanExecuteChanged;

        public NavigationCommand(HomeViewModel homeVm)
        {
            HomeVm = homeVm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeVm.Navigate();
        }

        
    }
}
